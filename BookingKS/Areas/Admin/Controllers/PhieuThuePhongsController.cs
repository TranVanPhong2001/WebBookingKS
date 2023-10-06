using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookingKS.Models;

namespace BookingKS.Areas.Admin.Controllers
{
    public class PhieuThuePhongsController : Controller
    {
        private HotelContext db = new HotelContext();

        // GET: Admin/PhieuThuePhongs
        public ActionResult Index()
        {
            var phieuThuePhongs = db.PhieuThuePhongs.Include(p => p.KhachHang).Include(p => p.NhanVien).Include(p => p.PhieuDatPhong);
            return View(phieuThuePhongs.ToList());
        }

        // GET: Admin/PhieuThuePhongs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuThuePhong phieuThuePhong = db.PhieuThuePhongs.Find(id);
            if (phieuThuePhong == null)
            {
                return HttpNotFound();
            }
            return View(phieuThuePhong);
        }

        // GET: Admin/PhieuThuePhongs/Create
        public ActionResult Create()
        {
            ViewBag.maKH = new SelectList(db.KhachHangs, "maKH", "tenKH");
            ViewBag.maNV = new SelectList(db.NhanViens, "maNV", "tenNV");
            ViewBag.maPDP = new SelectList(db.PhieuDatPhongs, "maPDP", "maPDP");
            return View();
        }

        // POST: Admin/PhieuThuePhongs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "maPTP,ngayThue,ngayTra,maPDP,maKH,maNV")] PhieuThuePhong phieuThuePhong)
        {
            if (ModelState.IsValid)
            {
                db.PhieuThuePhongs.Add(phieuThuePhong);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.maKH = new SelectList(db.KhachHangs, "maKH", "tenKH", phieuThuePhong.maKH);
            ViewBag.maNV = new SelectList(db.NhanViens, "maNV", "tenNV", phieuThuePhong.maNV);
            ViewBag.maPDP = new SelectList(db.PhieuDatPhongs, "maPDP", "maPDP", phieuThuePhong.maPDP);
            return View(phieuThuePhong);
        }

        // GET: Admin/PhieuThuePhongs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuThuePhong phieuThuePhong = db.PhieuThuePhongs.Find(id);
            if (phieuThuePhong == null)
            {
                return HttpNotFound();
            }
            ViewBag.maKH = new SelectList(db.KhachHangs, "maKH", "tenKH", phieuThuePhong.maKH);
            ViewBag.maNV = new SelectList(db.NhanViens, "maNV", "tenNV", phieuThuePhong.maNV);
            ViewBag.maPDP = new SelectList(db.PhieuDatPhongs, "maPDP", "maPDP", phieuThuePhong.maPDP);
            return View(phieuThuePhong);
        }

        // POST: Admin/PhieuThuePhongs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "maPTP,ngayThue,ngayTra,maPDP,maKH,maNV")] PhieuThuePhong phieuThuePhong)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phieuThuePhong).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.maKH = new SelectList(db.KhachHangs, "maKH", "tenKH", phieuThuePhong.maKH);
            ViewBag.maNV = new SelectList(db.NhanViens, "maNV", "tenNV", phieuThuePhong.maNV);
            ViewBag.maPDP = new SelectList(db.PhieuDatPhongs, "maPDP", "maPDP", phieuThuePhong.maPDP);
            return View(phieuThuePhong);
        }

        // GET: Admin/PhieuThuePhongs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuThuePhong phieuThuePhong = db.PhieuThuePhongs.Find(id);
            if (phieuThuePhong == null)
            {
                return HttpNotFound();
            }
            return View(phieuThuePhong);
        }

        // POST: Admin/PhieuThuePhongs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PhieuThuePhong phieuThuePhong = db.PhieuThuePhongs.Find(id);
            db.PhieuThuePhongs.Remove(phieuThuePhong);
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
