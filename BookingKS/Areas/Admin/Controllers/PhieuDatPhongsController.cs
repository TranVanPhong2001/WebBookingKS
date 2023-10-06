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
    public class PhieuDatPhongsController : Controller
    {
        private HotelContext db = new HotelContext();

        // GET: Admin/PhieuDatPhongs
        public ActionResult Index()
        {
            var phieuDatPhongs = db.PhieuDatPhongs.Include(p => p.KhachHang).Include(p => p.NhanVien);
            return View(phieuDatPhongs.ToList());
        }

        // GET: Admin/PhieuDatPhongs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuDatPhong phieuDatPhong = db.PhieuDatPhongs.Find(id);
            if (phieuDatPhong == null)
            {
                return HttpNotFound();
            }
            return View(phieuDatPhong);
        }

        // GET: Admin/PhieuDatPhongs/Create
        public ActionResult Create()
        {
            ViewBag.maKH = new SelectList(db.KhachHangs, "maKH", "tenKH");
            ViewBag.maNV = new SelectList(db.NhanViens, "maNV", "tenNV");
            return View();
        }

        // POST: Admin/PhieuDatPhongs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "maPDP,ngayDen,ngayDi,tongTienCoc,soNguoi,maKH,maNV")] PhieuDatPhong phieuDatPhong)
        {
            if (ModelState.IsValid)
            {
                db.PhieuDatPhongs.Add(phieuDatPhong);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.maKH = new SelectList(db.KhachHangs, "maKH", "tenKH", phieuDatPhong.maKH);
            ViewBag.maNV = new SelectList(db.NhanViens, "maNV", "tenNV", phieuDatPhong.maNV);
            return View(phieuDatPhong);
        }

        // GET: Admin/PhieuDatPhongs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuDatPhong phieuDatPhong = db.PhieuDatPhongs.Find(id);
            if (phieuDatPhong == null)
            {
                return HttpNotFound();
            }
            ViewBag.maKH = new SelectList(db.KhachHangs, "maKH", "tenKH", phieuDatPhong.maKH);
            ViewBag.maNV = new SelectList(db.NhanViens, "maNV", "tenNV", phieuDatPhong.maNV);
            return View(phieuDatPhong);
        }

        // POST: Admin/PhieuDatPhongs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "maPDP,ngayDen,ngayDi,tongTienCoc,soNguoi,maKH,maNV")] PhieuDatPhong phieuDatPhong)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phieuDatPhong).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.maKH = new SelectList(db.KhachHangs, "maKH", "tenKH", phieuDatPhong.maKH);
            ViewBag.maNV = new SelectList(db.NhanViens, "maNV", "tenNV", phieuDatPhong.maNV);
            return View(phieuDatPhong);
        }

        // GET: Admin/PhieuDatPhongs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuDatPhong phieuDatPhong = db.PhieuDatPhongs.Find(id);
            if (phieuDatPhong == null)
            {
                return HttpNotFound();
            }
            return View(phieuDatPhong);
        }

        // POST: Admin/PhieuDatPhongs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PhieuDatPhong phieuDatPhong = db.PhieuDatPhongs.Find(id);
            db.PhieuDatPhongs.Remove(phieuDatPhong);
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
