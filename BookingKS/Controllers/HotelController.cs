using BookingKS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using System.Web.UI;
using System.Net.NetworkInformation;
using System.Net;
using System.Net.Mail;
using System.Security.Policy;

namespace BookingKS.Controllers
{
    public class HotelController : Controller
    {
        private HotelContext db = new HotelContext();
        // GET: Hotel
        public ActionResult Index(int? page)
        {
            const int PAGE_SIZE = 6; // Số sản phẩm hiển thị trên mỗi trang
            int pageNumber = (page ?? 1); // Trang hiện tại (mặc định là trang 1)

            var listHotel = db.Phongs.OrderBy(m => m.maPhong).Skip((pageNumber - 1) * PAGE_SIZE).Take(PAGE_SIZE).ToList();

            ViewBag.CurrentPage = pageNumber;
            ViewBag.TotalPages = Math.Ceiling((double)db.Phongs.Count() / PAGE_SIZE);

            return View("Index", listHotel);                      
        }
        public ActionResult Details(int? Id)
        {
            var chitiet = db.Phongs.FirstOrDefault(x => x.maPhong == Id);
            chitiet.Luot += 1;
            db.SaveChanges();
            return View(chitiet);
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Service()
        {
            return View();
        }
        public ActionResult Room(int? page)
        {
            const int PAGE_SIZE = 6; // Số sản phẩm hiển thị trên mỗi trang
            int pageNumber = (page ?? 1); // Trang hiện tại (mặc định là trang 1)

            var listHotel = db.Phongs.OrderBy(m => m.maPhong).Skip((pageNumber - 1) * PAGE_SIZE).Take(PAGE_SIZE).ToList();

            ViewBag.CurrentPage = pageNumber;
            ViewBag.TotalPages = Math.Ceiling((double)db.Phongs.Count() / PAGE_SIZE);
            return View("Room", listHotel);            
        }
        public ActionResult Booking(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Phong phong = db.Phongs.Find(id);           
            ViewBag.MaPhongID = phong.maPhong;
            ViewBag.MaPhong1 = "(" + phong.tenPhong + phong.LoaiPhong.tenLP+ ")";
            ViewBag.MaPhong2 = ("Phòng: " + phong.tenPhong ,"Loại phòng: " +phong.LoaiPhong.tenLP);
            ViewBag.maPhong = new SelectList(db.Phongs, "maPhong", "tenPhong");
            if (phong == null)
            {
                return HttpNotFound();
            }
            return View(phong);
            

           
        }
        [HttpPost]
        public ActionResult Booking(KhachHang khachhang, PhieuDatPhong phieudatphong, CT_PhieuDatPhong ctphieudatphong, SendMail sendMail)
        {

            if (ModelState.IsValid)
            {
                // lưu thông tin khách hàng
                KhachHang kh = new KhachHang();               
                kh.tenKH = khachhang.tenKH;
                kh.gioiTinh = khachhang.gioiTinh;
                kh.diaChi = khachhang.diaChi;
                kh.CCCD = khachhang.CCCD;
                kh.email = khachhang.email;
                kh.sdt = khachhang.sdt;
                db.KhachHangs.Add(kh);
                db.SaveChanges();

                // Lưu thông tin Phiếu đặt phòng

                DateTime currentDate = DateTime.Now.Date;
                if (phieudatphong.ngayDen < currentDate || phieudatphong.ngayDi < currentDate)
                {
                    ModelState.AddModelError("", "Ngày đến và ngày đi không thể đặt trong quá khứ.");
                    return View();
                }

                // Kiểm tra ngày đến phải trước ngày đi
                if (phieudatphong.ngayDen > phieudatphong.ngayDi)
                {
                    ModelState.AddModelError("", "Ngày đến phải trước ngày đi.");
                    return View();
                }

                PhieuDatPhong pdp = new PhieuDatPhong();                             
                pdp.ngayDen = phieudatphong.ngayDen;
                pdp.ngayDi = phieudatphong.ngayDi;
                pdp.tongTienCoc = 500000;
                pdp.soNguoi = phieudatphong.soNguoi;                
                pdp.maNV= phieudatphong.maNV;
                pdp.maKH = kh.maKH;
                db.PhieuDatPhongs.Add(pdp);
                db.SaveChanges();

                

                //sendMail
                decimal tongTien = (decimal)pdp.tongTienCoc;
                MailMessage mail = new MailMessage();
                mail.To.Add(khachhang.email);
                mail.From = new MailAddress("ptr210701@gmail.com");
                mail.Subject = "Xác nhận đơn hàng từ Hotel QP";
                string Body = $"Xin chào, {kh.tenKH}<br /><br />" +
                              $"Bạn đã đặt PHÒNG thành công với mã phòng {ctphieudatphong.maPhong} và tổng tiền cọc là {tongTien.ToString("N0")} VNĐ." +
                              $" Vui lòng thanh toán để hoàn tất thủ tục nhận phòng<br /><br />" +
                              $"Trân trọng,<br />Hotel QP";

                mail.Body = Body;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential("ptr210701@gmail.com", "oizvswdwrysamqqc"); // Enter seders User name and password  
                smtp.EnableSsl = true;
                smtp.Send(mail);
                ViewBag.Message = "Đã gởi thành công !!!";

                // Lưu chi tiết phiếu đặt phòng

                CT_PhieuDatPhong ctpdp = new CT_PhieuDatPhong();
                ctpdp.maPDP = pdp.maPDP;
                ctpdp.maPhong = ctphieudatphong.maPhong;
                ctpdp.tienCoc = pdp.tongTienCoc;
                db.CT_PhieuDatPhong.Add(ctpdp);
                db.SaveChanges();

                TempData["maPDP"] = ctpdp.maPDP;
                return RedirectToAction("PaymentWithPaypal", "ShoppingCart");
            }
                             

            return View();

        }             

        public ActionResult Contact()
        {           
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact([Bind(Include = "Id,hoTen,sdt,email,ngayGui,NoiDung")] LienHe lienHe)
        {
            if (ModelState.IsValid)
            {
                lienHe.ngayGui = DateTime.UtcNow;
                db.LienHes.Add(lienHe);
                db.SaveChanges();
                return RedirectToAction("Contact");
            }     
            return View(lienHe);
        }
       

        
    }
}