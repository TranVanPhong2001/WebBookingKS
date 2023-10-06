using BookingKS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookingKS.Areas.Admin.Controllers
{
    public class QuanLyPhongController : Controller
    {
        private readonly HotelContext db = new HotelContext();
        // GET: Admin/DanhSachPhong
        [Authorize]
        public ActionResult Index()
        {
            var listPhong = db.Phongs.ToList();

            return View(listPhong);
        }
    }
}