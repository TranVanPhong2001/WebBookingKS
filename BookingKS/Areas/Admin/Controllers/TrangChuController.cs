using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookingKS.Areas.Admin.Controllers
{
    public class TrangChuController : Controller
    {
        // GET: Admin/QLHotel
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}