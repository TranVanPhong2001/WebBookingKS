using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing.Printing;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using BookingKS.Models;
using PagedList;

namespace BookingKS.Controllers
{
    public class RoomController : Controller
    {
        private HotelContext db = new HotelContext();

        // GET: Phongs
        public ActionResult Index(int? page, string searchString)
        {
            //const int PAGE_SIZE = 6; // Số sản phẩm hiển thị trên mỗi trang
            //int pageNumber = (page ?? 1); // Trang hiện tại (mặc định là trang 1)

            //var listHotel = db.Phongs.OrderBy(m => m.maPhong).Skip((pageNumber - 1) * PAGE_SIZE).Take(PAGE_SIZE).ToList();

            //ViewBag.CurrentPage = pageNumber;
            //ViewBag.TotalPages = Math.Ceiling((double)db.Phongs.Count() / PAGE_SIZE);

            //return View("Index", listHotel);
            ViewBag.KeyWord = searchString;
            if (page == null)
                page = 1;
            int pageSize = 6;
            int pageNumber = (page ?? 1);

            ViewBag.TotalPages = Math.Ceiling((double)db.Phongs.Count() / pageSize);
            ViewBag.CurrentPage = pageNumber;
            ViewBag.maLP = Phong.GetAll(searchString);
            return View(Phong.GetAll(searchString).ToPagedList(page.Value, pageSize));
        }

        // GET: Phongs/Details/5
        public ActionResult Details(int? id)
        {
            var chitiet = db.Phongs.FirstOrDefault(x => x.maPhong == id);
            chitiet.Luot += 1;
            db.SaveChanges();
            return View(chitiet);
        }
        public ActionResult Search(string searchString, int? page)
        {
            const int PAGE_SIZE = 6; // Số sản phẩm hiển thị trên mỗi trang
            int pageNumber = (page ?? 1); // Trang hiện tại (mặc định là trang 1)
            var danhsachphong = db.Phongs.Where(p => p.LoaiPhong.tenLP.Contains(searchString)).Take(PAGE_SIZE).ToList();
            ViewBag.CurrentPage = pageNumber;
            ViewBag.TotalPages = Math.Ceiling((double)db.Phongs.Count() / PAGE_SIZE);
            return View("Index", danhsachphong);
        }
        public ActionResult PhanLoaiPhong(string phanloaiphong)
        {
            var dslp = db.Phongs.Where(p => p.LoaiPhong.tenLP.Contains(phanloaiphong)).ToList();
            ViewBag.maLP= new SelectList(dslp, "ma_LP", "tenLP");
            return View("PhanLoaiPhong", dslp);
        }



    }
}
