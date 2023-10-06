using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookingKS.Models;

namespace BookingKS.Areas.Admin.Controllers
{
    public class PhongsController : Controller
    {
        private HotelContext db = new HotelContext();

     
        // GET: Admin/Phongs
        [Authorize]
        public ActionResult Index()
        {
            var phongs = db.Phongs.Include(p => p.LoaiPhong);
            return View(phongs.ToList());
        }

        // GET: Admin/Phongs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phong phong = db.Phongs.Find(id);
            if (phong == null)
            {
                return HttpNotFound();
            }
            return View(phong);
        }

        // GET: Admin/Phongs/Create
        public ActionResult Create()
        {
            ViewBag.maLP = new SelectList(db.LoaiPhongs, "ma_LP", "tenLP");
            return View();
        }

        // POST: Admin/Phongs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "maPhong,tenPhong,maLP,Image,sucChua,donGia,moTa,tinhTrang")] Phong phong, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                //luu hinh vao web server
                if(Image != null){
                    string  path = Path.Combine(Server.MapPath("~/Content/Theme_KS/img/"), Path.GetFileName(Image.FileName));
                    Image.SaveAs(path); 

                }
                //luu phong vao db
                phong.Image = "/Content/Theme_KS/img/" + Path.GetFileName(Image.FileName); 
                db.Phongs.Add(phong);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.maLP = new SelectList(db.LoaiPhongs, "ma_LP", "tenLP", phong.maLP);
            return View(phong);
        }

        // GET: Admin/Phongs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phong phong = db.Phongs.Find(id);
            if (phong == null)
            {
                return HttpNotFound();
            }
            ViewBag.maLP = new SelectList(db.LoaiPhongs, "ma_LP", "tenLP", phong.maLP);
            return View(phong);
        }

        // POST: Admin/Phongs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "maPhong,tenPhong,maLP,Image,sucChua,donGia,moTa,tinhTrang")] Phong phong)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phong).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.maLP = new SelectList(db.LoaiPhongs, "ma_LP", "tenLP", phong.maLP);
            return View(phong);
        }

        // GET: Admin/Phongs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phong phong = db.Phongs.Find(id);
            if (phong == null)
            {
                return HttpNotFound();
            }
            return View(phong);
        }

        // POST: Admin/Phongs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Phong phong = db.Phongs.Find(id);
            db.Phongs.Remove(phong);
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
        public ActionResult Search(string searchString)
        {
            var timphong = db.Phongs.Where(p => p.tenPhong.Contains(searchString)).ToList();
            
            return View("Index", timphong);
        }
    }
}
