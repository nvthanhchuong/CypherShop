using CypherShop.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;

namespace CypherShop.Controllers
{
    public class DonDatHangController : Controller
    {
        // GET: Dondathang
        CypherShopEntities db = new CypherShopEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DanhSachDDH(int? page)
        {
            if (Session["Taikhoan"] != null)
            {

                int pagesize = 7;
                int pagenum = (page ?? 1);
                return View(db.DONDATHANGs.ToList().OrderByDescending(n => n.MaDonHang).ToPagedList(pagenum, pagesize));

            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }

        public ActionResult DanhSachDDH1(int? page)
        {
            if (Session["Taikhoan"] != null)
            {

                int pagesize = 7;
                int pagenum = (page ?? 1);
                return View(db.DONDATHANGs.ToList().OrderByDescending(n => n.MaDonHang).ToPagedList(pagenum, pagesize));

            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }

        public ActionResult ChiTiet(int? page)
        {
            if (Session["Taikhoan"] != null)
            {

                int pagesize = 7;
                int pagenum = (page ?? 1);
                return View(db.CHITIETDONTHANGs.ToList().OrderByDescending(n => n.MaDonHang).ToPagedList(pagenum, pagesize));

            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }
        public ActionResult ChiTiet1(int? page)
        {
            if (Session["Taikhoan"] != null)
            {

                int pagesize = 7;
                int pagenum = (page ?? 1);
                return View(db.CHITIETDONTHANGs.ToList().OrderByDescending(n => n.MaDonHang).ToPagedList(pagenum, pagesize));

            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }

        public ActionResult Timkiem(int SearchString)
        {
            if (Session["Taikhoan"] != null)
            {
                var lstsp = db.DONDATHANGs.Where(a => a.MaDonHang.Equals(SearchString)).ToList();
                return View(lstsp);
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }
        public ActionResult Timkiem1(int SearchString)
        {
            if (Session["Taikhoan"] != null)
            {
                var lstsp = db.DONDATHANGs.Where(a => a.MaDonHang.Equals(SearchString)).ToList();
                return View(lstsp);
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }

        public ActionResult TimkiemCt(int SearchString)
        {
            if (Session["Taikhoan"] != null)
            {
                var lstsp = db.CHITIETDONTHANGs.Where(a => a.MaDonHang.Equals(SearchString)).ToList();
                return View(lstsp);
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }
        public ActionResult TimkiemCt1(int SearchString)
        {
            if (Session["Taikhoan"] != null)
            {
                var lstsp = db.CHITIETDONTHANGs.Where(a => a.MaDonHang.Equals(SearchString)).ToList();
                return View(lstsp);
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }



        [HttpPost]
        public ActionResult ThemCt1(CHITIETDONTHANG t)
        {



            ViewBag.MaSP = new SelectList(db.SANPHAMs.ToList().OrderBy(n => n.MaSP), "MaSP", "TenSP");


            var lg = db.DONDATHANGs.Where(a => a.MaDonHang.Equals(t.MaDonHang)).FirstOrDefault();
            if (lg != null)
            {
                db.CHITIETDONTHANGs.Add(t);
                db.SaveChanges();
                Response.Write("<script>alert('Thêm thành công')</script>");
                ModelState.Clear();
                return View();
            }
            else
            {

                Response.Write("<script>alert('Đơn hàng không tồn tại')</script>");
                return View();
            }



        }
        public ActionResult CapNhat(int id)
        {
            if (Session["Taikhoan"] != null)
            {
                ViewBag.MaPhuongThuc = new SelectList(db.PHUONGTHUCTHANHTOANs.ToList().OrderBy(n => n.MaPhuongThuc), "MaPhuongThuc", "TenPhuongThuc");

                var sp = db.DONDATHANGs.Find(id);
                return View(sp);
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }

        [HttpPost]
        public ActionResult CapNhat(DONDATHANG t)
        {
            ViewBag.MaPhuongThuc = new SelectList(db.PHUONGTHUCTHANHTOANs.ToList().OrderBy(n => n.MaPhuongThuc), "MaPhuongThuc", "TenPhuongThuc");


            var lg = db.NHANVIENs.Where(a => a.MaNV.Equals(t.MANV)).FirstOrDefault();


            if (lg == null)
            {
                Response.Write("<script>alert('Mã nhân viên không tồn tại')</script>");
                return View();
            }
            else if (t.Ngaygiao == null)
            {
                Response.Write("<script>alert('Vui lòng nhập ngày giao')</script>");
                return View();
            }




            else
            {
                var update = db.DONDATHANGs.Find(t.MaDonHang);

                update.MaPhuongThuc = t.MaPhuongThuc;
                update.Ngaygiao = t.Ngaygiao;

                update.MANV = t.MANV;

                update.Trangthai = t.Trangthai;
                update.Tinhtranggiaohang = t.Tinhtranggiaohang;




                var id = db.SaveChanges();
                if (id > 0)
                {
                    return RedirectToAction("DanhSachDDH");

                }
                else
                {

                    return View(t);
                }
            }
        }

        public ActionResult CapNhat1(int id)
        {
            if (Session["Taikhoan"] != null)
            {
                ViewBag.MaPhuongThuc = new SelectList(db.PHUONGTHUCTHANHTOANs.ToList().OrderBy(n => n.MaPhuongThuc), "MaPhuongThuc", "TenPhuongThuc");

                var sp = db.DONDATHANGs.Find(id);
                return View(sp);
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }

        [HttpPost]
        public ActionResult CapNhat1(DONDATHANG t)
        {
            ViewBag.MaPhuongThuc = new SelectList(db.PHUONGTHUCTHANHTOANs.ToList().OrderBy(n => n.MaPhuongThuc), "MaPhuongThuc", "TenPhuongThuc");


            var lg = db.NHANVIENs.Where(a => a.MaNV.Equals(t.MANV)).FirstOrDefault();


            if (lg == null)
            {
                Response.Write("<script>alert('Mã nhân viên không tồn tại')</script>");
                return View();
            }

            else if (t.Ngaygiao == null)
            {
                Response.Write("<script>alert('Vui lòng nhập ngày giao')</script>");
                return View();
            }




            else
            {

                var update = db.DONDATHANGs.Find(t.MaDonHang);

                update.MaPhuongThuc = t.MaPhuongThuc;
                update.Ngaygiao = t.Ngaygiao;

                update.MANV = t.MANV;
                update.Trangthai = t.Trangthai;
                update.Tinhtranggiaohang = t.Tinhtranggiaohang;





                var id = db.SaveChanges();
                if (id > 0)
                {
                    return RedirectToAction("DanhSachDDH1");

                }
                else
                {

                    return View(t);
                }
            }
        }



    }
}