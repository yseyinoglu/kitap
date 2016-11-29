using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Admin.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Home
  
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }
        [AllowAnonymous, HttpPost]
        public ActionResult Login(string email, string password)
        {   //   LINQ
            kitapContainer db = new kitapContainer();
            User user = db.UserSet.FirstOrDefault(r => r.Mail == email && r.Password == password);
            if (user != null)
            {
                Session["user"] = user;
                return RedirectToAction("Index");
            }

            TempData["error"] = "Hatalı Kullanıcı Adı Veya Parola !";

            return View();
        }
        public ActionResult Logout()
        {
            Session.Remove("user");
            return Redirect("Index");
        }
    }
}