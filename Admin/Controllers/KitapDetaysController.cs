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
    public class KitapDetaysController : BaseController
    {
        private kitapContainer db = new kitapContainer();

        // GET: KitapDetays
        public ActionResult Index()
        {
            return View(db.KitapDetaySet.ToList());
        }

        // GET: KitapDetays/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KitapDetay kitapDetay = db.KitapDetaySet.Find(id);
            if (kitapDetay == null)
            {
                return HttpNotFound();
            }
            return View(kitapDetay);
        }

        // GET: KitapDetays/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KitapDetays/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,KitapSayfaNo,KitapYazari,KitapYayinTarihi,KitapBaskıSayısı,KitapBoyutu,KitapDili")] KitapDetay kitapDetay)
        {
            if (ModelState.IsValid)
            {
                db.KitapDetaySet.Add(kitapDetay);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kitapDetay);
        }

        // GET: KitapDetays/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KitapDetay kitapDetay = db.KitapDetaySet.Find(id);
            if (kitapDetay == null)
            {
                return HttpNotFound();
            }
            return View(kitapDetay);
        }

        // POST: KitapDetays/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,KitapSayfaNo,KitapYazari,KitapYayinTarihi,KitapBaskıSayısı,KitapBoyutu,KitapDili")] KitapDetay kitapDetay)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kitapDetay).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kitapDetay);
        }

        // GET: KitapDetays/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KitapDetay kitapDetay = db.KitapDetaySet.Find(id);
            if (kitapDetay == null)
            {
                return HttpNotFound();
            }
            return View(kitapDetay);
        }

        // POST: KitapDetays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KitapDetay kitapDetay = db.KitapDetaySet.Find(id);
            db.KitapDetaySet.Remove(kitapDetay);
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
