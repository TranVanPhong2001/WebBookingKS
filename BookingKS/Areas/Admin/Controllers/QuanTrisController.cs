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
    public class QuanTrisController : Controller
    {
        private HotelContext db = new HotelContext();

        // GET: Admin/QuanTris
        [HasCredential(IDQuyen = "QUANLYTAIKHOANNV")]
        public ActionResult Index()
        {
            var quanTris = db.QuanTris.Include(q => q.NhanVien).Include(q => q.NhomNhanSu);
            return View(quanTris.ToList());
        }

        // GET: Admin/QuanTris/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuanTri quanTri = db.QuanTris.Find(id);
            if (quanTri == null)
            {
                return HttpNotFound();
            }
            return View(quanTri);
        }

        // GET: Admin/QuanTris/Create
        [HasCredential(IDQuyen = "QUANLYTAIKHOANNV")]
        public ActionResult Create()
        {
            ViewBag.maNV = new SelectList(db.NhanViens, "maNV", "tenNV");
            ViewBag.IDNhom = new SelectList(db.NhomNhanSus, "IDNhom", "TenNhom");
            return View();
        }

        // POST: Admin/QuanTris/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [HasCredential(IDQuyen = "QUANLYTAIKHOANNV")]
        public ActionResult Create([Bind(Include = "username,password,tinhTrang,maNV,IDNhom")] QuanTri quanTri)
        {
            if (ModelState.IsValid)
            {
                QuanTri oldQuanTri = db.QuanTris.Find(quanTri.username);
                if (oldQuanTri == null)
                {
                    string passwordMD5 = Encryptor.MD5Hash(quanTri.password);
                    quanTri.password = passwordMD5;
                    db.QuanTris.Add(quanTri);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Tên tài khoản đã tồn tại.");
                }
            }

            ViewBag.maNV = new SelectList(db.NhanViens, "maNV", "tenNV", quanTri.maNV);
            ViewBag.IDNhom = new SelectList(db.NhomNhanSus, "IDNhom", "TenNhom", quanTri.IDNhom);
            return View(quanTri);
        }

        // GET: Admin/QuanTris/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuanTri quanTri = db.QuanTris.Find(id);
            if (quanTri == null)
            {
                return HttpNotFound();
            }
            ViewBag.oldPass = quanTri.password;
            ViewBag.maNV = new SelectList(db.NhanViens, "maNV", "tenNV", quanTri.maNV);
            ViewBag.IDNhom = new SelectList(db.NhomNhanSus, "IDNhom", "TenNhom", quanTri.IDNhom);
            return View(quanTri);
        }

        // POST: Admin/QuanTris/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "username,password,tinhTrang,maNV,IDNhom")] QuanTri quanTri, string oldPass)
        {
            if (ModelState.IsValid)
            {
                if (oldPass != quanTri.password)
                {
                    string passwordMD5 = Encryptor.MD5Hash(quanTri.password);
                    quanTri.password = passwordMD5;
                }
                db.Entry(quanTri).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.maNV = new SelectList(db.NhanViens, "maNV", "tenNV", quanTri.maNV);
            ViewBag.IDNhom = new SelectList(db.NhomNhanSus, "IDNhom", "TenNhom", quanTri.IDNhom);
            return View(quanTri);
        }

        // GET: Admin/QuanTris/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuanTri quanTri = db.QuanTris.Find(id);
            if (quanTri == null)
            {
                return HttpNotFound();
            }
            return View(quanTri);
        }

        // POST: Admin/QuanTris/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            QuanTri quanTri = db.QuanTris.Find(id);
            db.QuanTris.Remove(quanTri);
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
