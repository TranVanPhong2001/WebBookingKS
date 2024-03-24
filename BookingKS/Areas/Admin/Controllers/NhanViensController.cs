using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookingKS.Areas.Admin.Common;
using BookingKS.Models;

namespace BookingKS.Areas.Admin.Controllers
{
    public class NhanViensController : BaseController
    {
        private HotelContext db = new HotelContext();

        // GET: Admin/NhanViens
        [HasCredential(IDQuyen = "QUANLYNHANVIEN")]
        public ActionResult Index()
        {
            return View(db.NhanViens.ToList());
        }

        // GET: Admin/NhanViens/Details/5
        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanVien = db.NhanViens.Find(id);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            return View(nhanVien);
        }

        // GET: Admin/NhanViens/Create
       
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/NhanViens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public ActionResult Create([Bind(Include = "maNV,tenNV,gioiTinh,ngaySinh,diaChi,sdt,email,ImageNV")] NhanVien nhanVien, HttpPostedFileBase ImageNV)
        {
            if (ModelState.IsValid)
            {
                //luu hinh vao web server
                if (ImageNV != null)
                {
                    string path = Path.Combine(Server.MapPath("/Data/"), Path.GetFileName(ImageNV.FileName));
                    ImageNV.SaveAs(path);
                }

                //luu imageNV vao db             
                nhanVien.ImageNV = "/Data/" + Path.GetFileName(ImageNV.FileName);
                db.NhanViens.Add(nhanVien);
                db.SaveChanges();
                return RedirectToAction("Index"); 
            }

            return View(nhanVien);
        }

        // GET: Admin/NhanViens/Edit/5
        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanVien = db.NhanViens.Find(id);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            return View(nhanVien);
        }

        // POST: Admin/NhanViens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public ActionResult Edit([Bind(Include = "maNV,tenNV,gioiTinh,ngaySinh,diaChi,sdt,email,ImageNV")] NhanVien nhanVien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nhanVien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nhanVien);
        }

        // GET: Admin/NhanViens/Delete/5
        
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanVien = db.NhanViens.Find(id);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            return View(nhanVien);
        }

        // POST: Admin/NhanViens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [HasCredential(IDQuyen = "QUANLYNHANVIEN")]
        public ActionResult DeleteConfirmed(int id)
        {
            NhanVien nhanVien = db.NhanViens.Find(id);
            db.NhanViens.Remove(nhanVien);
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
