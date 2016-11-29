using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Data;
using Admin.Controllers;

namespace Admin.Filters
{
    public class YorumsController : BaseController
    {
        private kitapContainer db = new kitapContainer();

        // GET: Yorums
        public ActionResult Index()
        {
            var yorumSet = db.YorumSet.Include(y => y.User).Include(y => y.Kitapİlan);
            return View(yorumSet.ToList());
        }

        // GET: Yorums/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yorum yorum = db.YorumSet.Find(id);
            if (yorum == null)
            {
                return HttpNotFound();
            }
            return View(yorum);
        }

        // GET: Yorums/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.UserSet, "Id", "Name");
            ViewBag.KitapİlanId = new SelectList(db.KitapİlanSet, "Id", "Baslik");
            return View();
        }

        // POST: Yorums/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Text,Tarih,Verified,UserId,KitapİlanId")] Yorum yorum)
        {
            if (ModelState.IsValid)
            {
                db.YorumSet.Add(yorum);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.UserSet, "Id", "Name", yorum.UserId);
            ViewBag.KitapİlanId = new SelectList(db.KitapİlanSet, "Id", "Baslik", yorum.KitapİlanId);
            return View(yorum);
        }

        // GET: Yorums/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yorum yorum = db.YorumSet.Find(id);
            if (yorum == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.UserSet, "Id", "Name", yorum.UserId);
            ViewBag.KitapİlanId = new SelectList(db.KitapİlanSet, "Id", "Baslik", yorum.KitapİlanId);
            return View(yorum);
        }

        // POST: Yorums/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Text,Tarih,Verified,UserId,KitapİlanId")] Yorum yorum)
        {
            if (ModelState.IsValid)
            {
                db.Entry(yorum).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.UserSet, "Id", "Name", yorum.UserId);
            ViewBag.KitapİlanId = new SelectList(db.KitapİlanSet, "Id", "Baslik", yorum.KitapİlanId);
            return View(yorum);
        }

        // GET: Yorums/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Yorum yorum = db.YorumSet.Find(id);
            if (yorum == null)
            {
                return HttpNotFound();
            }
            return View(yorum);
        }

        // POST: Yorums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Yorum yorum = db.YorumSet.Find(id);
            db.YorumSet.Remove(yorum);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
