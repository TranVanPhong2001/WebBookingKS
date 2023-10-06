using BookingKS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace BookingKS.Controllers
{
    public class HomeController : Controller
    {
        private HotelContext db = new HotelContext();
        public ActionResult Index(int? page)
        {
            const int PAGE_SIZE = 6; // Số sản phẩm hiển thị trên mỗi trang
            int pageNumber = (page ?? 1); // Trang hiện tại (mặc định là trang 1)

            var listHotel = db.Phongs.OrderBy(m => m.maPhong).Skip((pageNumber - 1) * PAGE_SIZE).Take(PAGE_SIZE).ToList();

            ViewBag.CurrentPage = pageNumber;
            ViewBag.TotalPages = Math.Ceiling((double)db.Phongs.Count() / PAGE_SIZE);

            return View("Index", listHotel);
            
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}