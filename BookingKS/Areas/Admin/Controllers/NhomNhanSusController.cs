using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookingKS.Areas.Admin.Common;
using BookingKS.Models;

namespace BookingKS.Areas.Admin.Controllers
{
    public class NhomNhanSusController : Controller
    {
        private HotelContext db = new HotelContext();

        // GET: Admin/NhomNhanSus
        [HasCredential(IDQuyen = "NHOMNHANSU")]
        public ActionResult Index()
        {
            return View(db.NhomNhanSus.ToList());
        }

        // GET: Admin/NhomNhanSus/Details/5
        [HasCredential(IDQuyen = "NHOMNHANSU")]
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhomNhanSu nhomNhanSu = db.NhomNhanSus.Find(id);
            if (nhomNhanSu == null)
            {
                return HttpNotFound();
            }
            return View(nhomNhanSu);
        }

        // GET: Admin/NhomNhanSus/Create
        [HasCredential(IDQuyen = "NHOMNHANSU")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/NhomNhanSus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [HasCredential(IDQuyen = "NHOMNHANSU")]
        public ActionResult Create([Bind(Include = "IDNhom,TenNhom")] NhomNhanSu nhomNhanSu)
        {
            if (ModelState.IsValid)
            {
                db.NhomNhanSus.Add(nhomNhanSu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nhomNhanSu);
        }

        // GET: Admin/NhomNhanSus/Edit/5
        [HasCredential(IDQuyen = "NHOMNHANSU")]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhomNhanSu nhomNhanSu = db.NhomNhanSus.Find(id);
            if (nhomNhanSu == null)
            {
                return HttpNotFound();
            }
            return View(nhomNhanSu);
        }

        // POST: Admin/NhomNhanSus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [HasCredential(IDQuyen = "NHOMNHANSU")]
        public ActionResult Edit([Bind(Include = "IDNhom,TenNhom")] NhomNhanSu nhomNhanSu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nhomNhanSu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nhomNhanSu);
        }

        // GET: Admin/NhomNhanSus/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhomNhanSu nhomNhanSu = db.NhomNhanSus.Find(id);
            if (nhomNhanSu == null)
            {
                return HttpNotFound();
            }
            return View(nhomNhanSu);
        }

        // POST: Admin/NhomNhanSus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            NhomNhanSu nhomNhanSu = db.NhomNhanSus.Find(id);
            db.NhomNhanSus.Remove(nhomNhanSu);
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
