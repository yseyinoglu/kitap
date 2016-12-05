using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data;

namespace Web.Controllers
{
    public class KitapController : BaseController
    {
        // GET: Kitap
        public ActionResult Index(int id = 0, int start = 0, int pageSize = 25, string query = "")
        {
            var kitaplar = kitap.KitapİlanSet.AsQueryable();

            if (id > 0)
            {
                kitaplar = kitaplar.Where(q => q.KategoriId == id);
            }

            if (query.Length > 0)
            {
                kitaplar = kitaplar.Where(q => q.Baslik.Contains(query) || q.Baslik.Contains(query));
            }

            kitaplar.OrderByDescending(q => q.Id).Skip(start).Take(pageSize);

            ViewBag.start = start + pageSize;
            ViewBag.pageSize = pageSize;

            return View(kitaplar);
        }
        public ActionResult Show(int id = 0)
        {
            Kitapİlan kitaplar = kitap.KitapİlanSet.FirstOrDefault(q => q.Id == id);
            return View(kitaplar);
        }

        [HttpPost]
        public ActionResult Comment(int post_id, String comment_text)
        {
            var user = (User)Session["user"];

            if (user == null)
            {
                TempData["comment_error"] = "Giriş yapmadan yorum yapamasınız !";
                return Redirect(Request.UrlReferrer.ToString());
            }

            if (comment_text == "" || post_id < 1)
            {
                TempData["comment_error"] = "Formdaki eksikleri doldurunuz !";
                return Redirect(Request.UrlReferrer.ToString());
            }

            var comment = new Yorum();
            comment.Tarih = DateTime.Now;
            comment.KitapİlanId = post_id;
            comment.Text = comment_text;
            comment.UserId = user.Id;
            comment.Verified = false;

            kitap.YorumSet.Add(comment);
            kitap.SaveChanges();

            TempData["comment_success"] = "Yorumunuz onay sonrasında yayına alınacaktır, teşekkürler !";
            return Redirect(Request.UrlReferrer.ToString());
        }
         [HttpPost]
       public ActionResult CommentAjax(int post_id, String comment_text)
       {
           Comment(post_id, comment_text);

           if(TempData["comment_error"] != null){
               return Content(TempData["comment_error"].ToString());
           }
           return Content(TempData["comment_success"].ToString()); 
       }

       public ActionResult Json(int id)
       {
           var list = kitap.KitapİlanSet.Where(q => q.KategoriId == id).Select(x => new { x.Id, x.Baslik });
           return Json(list, JsonRequestBehavior.AllowGet);
       }
    }
    }
