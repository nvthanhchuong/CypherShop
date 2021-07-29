using CypherShop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;


namespace CypherShop.Controllers
{
    public class KhachHangController : Controller
    {
        // GET: KhachHang
        CypherShopEntities db = new CypherShopEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DanhSachKhachHang(int? page)
        {
            if (Session["Taikhoan"] != null)
            {
                int pagesize = 7;
                int pagenum = (page ?? 1);
                return View(db.KHACHHANGs.ToList().OrderByDescending(n => n.MaKH).ToPagedList(pagenum, pagesize));
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }

        public ActionResult DanhSachKhachHang1(int? page)
        {
            if (Session["Taikhoan"] != null)
            {
                int pagesize = 7;
                int pagenum = (page ?? 1);
                return View(db.KHACHHANGs.ToList().OrderByDescending(n => n.MaKH).ToPagedList(pagenum, pagesize));
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }

        public ActionResult Timkiem(string SearchString)
        {
            if (Session["Taikhoan"] != null)
            {
                var lstsp = db.KHACHHANGs.Where(a => a.Ten.Contains(SearchString)).ToList();

                return View(lstsp);
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }
        public ActionResult Timkiem1(string SearchString)
        {
            if (Session["Taikhoan"] != null)
            {
                var lstsp = db.KHACHHANGs.Where(a => a.Ten.Contains(SearchString)).ToList();
                return View(lstsp);
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }

        public ActionResult ThemKhachHang()
        {
            if (Session["Taikhoan"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }

        [HttpPost]
        public ActionResult ThemKhachHang(KHACHHANG t)
        {
            if (t.Taikhoan == null)
            {
                ModelState.Clear();
                Response.Write("<script>alert('Vui điền tên đăng nhập')</script>");
                return View();
            }

            else if (db.KHACHHANGs.Any(x => x.Taikhoan == t.Taikhoan))
            {
                ModelState.Clear();
                Response.Write("<script>alert('Tài khoản đã tồn tại')</script>");
                return View();
            }
            else if (db.KHACHHANGs.Any(x => x.Email == t.Email))
            {
                ModelState.Clear();
                Response.Write("<script>alert('Email đã được sử dụng')</script>");
                return View();
            }
            else if (t.Matkhau == null)
            {
                ModelState.Clear();
                Response.Write("<script>alert('Vui lòng nhập mật khẩu')</script>");
                return View();
            }
            else if (t.Matkhau.Length < 6)
            {
                ModelState.Clear();
                Response.Write("<script>alert('Mật khẩu từ 6 kí tự trở lên')</script>");
                return View();
            }
            else if (t.NhapLaimatkhau == null)
            {
                ModelState.Clear();
                Response.Write("<script>alert('Vui lòng nhập lại mật khẩu')</script>");
                return View();
            }
            else if (t.Matkhau != t.NhapLaimatkhau)
            {
                ModelState.Clear();
                Response.Write("<script>alert('Vui lòng nhập lại mật khẩu chính xác')</script>");
                return View();
            }
            else if (t.Email == null)
            {
                ModelState.Clear();
                Response.Write("<script>alert('Vui lòng nhập Email')</script>");
                return View();
            }
            else
            {
                db.KHACHHANGs.Add(t);
                db.SaveChanges();
                ModelState.Clear();
                Response.Write("<script>alert('Thêm thành công')</script>");
                return View();

            }
        }

        public ActionResult ThemKhachHang1()
        {
            if (Session["Taikhoan"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }

        [HttpPost]
        public ActionResult ThemKhachHang1(KHACHHANG t)
        {
            if (t.Taikhoan == null)
            {
                ModelState.Clear();
                Response.Write("<script>alert('Vui điền tên đăng nhập')</script>");
                return View();
            }

            else if (db.KHACHHANGs.Any(x => x.Taikhoan == t.Taikhoan))
            {
                ModelState.Clear();
                Response.Write("<script>alert('Tài khoản đã tồn tại')</script>");
                return View();
            }
            else if (db.KHACHHANGs.Any(x => x.Email == t.Email))
            {
                ModelState.Clear();
                Response.Write("<script>alert('Email đã được sử dụng')</script>");
                return View();
            }
            else if (t.Matkhau == null)
            {
                ModelState.Clear();
                Response.Write("<script>alert('Vui lòng nhập mật khẩu')</script>");
                return View();
            }
            else if (t.Matkhau.Length < 6)
            {
                ModelState.Clear();
                Response.Write("<script>alert('Mật khẩu từ 6 kí tự trở lên')</script>");
                return View();
            }
            else if (t.NhapLaimatkhau == null)
            {
                ModelState.Clear();
                Response.Write("<script>alert('Vui lòng nhập lại mật khẩu')</script>");
                return View();
            }
            else if (t.Matkhau != t.NhapLaimatkhau)
            {
                ModelState.Clear();
                Response.Write("<script>alert('Vui lòng nhập lại mật khẩu chính xác')</script>");
                return View();
            }
            else if (t.Email == null)
            {
                ModelState.Clear();
                Response.Write("<script>alert('Vui lòng nhập Email')</script>");
                return View();
            }
            else
            {
                db.KHACHHANGs.Add(t);
                db.SaveChanges();
                ModelState.Clear();
                Response.Write("<script>alert('Thêm thành công')</script>");
                return View();

            }
        }

        public ActionResult XoaKhachHang(int id)
        {
            if (Session["Taikhoan"] != null)
            {
                var sp = db.KHACHHANGs.Find(id);
                db.KHACHHANGs.Remove(sp);
                db.SaveChanges();
                return RedirectToAction("DanhSachKhachHang", "KhachHang");
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }

        public ActionResult XoaKhachHang1(int id)
        {
            if (Session["Taikhoan"] != null)
            {
                var sp = db.KHACHHANGs.Find(id);
                db.KHACHHANGs.Remove(sp);
                db.SaveChanges();
                return RedirectToAction("DanhSachKhachHang1", "KhachHang");
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }

        public ActionResult CapNhat(int id)
        {
            if (Session["Taikhoan"] != null)
            {

                var sp = db.KHACHHANGs.Find(id);
                return View(sp);
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }

        [HttpPost]
        public ActionResult CapNhat(KHACHHANG t, HttpPostedFileBase fileupload)
        {
            

            if (t.Ten == null)
            {
                Response.Write("<script>alert('Vui lòng nhập tên')</script>");
                return View();
            }

            else if (t.Email == null)
            {
                Response.Write("<script>alert('Vui nhập Email')</script>");
                return View();
            }



            else
            {




                var update = db.KHACHHANGs.Find(t.MaKH);
                update.Ho = t.Ho;
                update.Tenlot = t.Tenlot;
                update.Ten = t.Ten;
                update.Email = t.Email;
                update.DiachiKH = t.DiachiKH;
                update.DienthoaiKH = t.DienthoaiKH;




                var id = db.SaveChanges();
                if (id > 0)
                {
                    return RedirectToAction("DanhSachKhachHang");

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

                var sp = db.KHACHHANGs.Find(id);
                return View(sp);
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }

        [HttpPost]
        public ActionResult CapNhat1(KHACHHANG t)
        {
            

            if (t.Ten == null)
            {
                Response.Write("<script>alert('Vui lòng nhập tên ')</script>");
                return View();
            }


            else if (t.Email == null)
            {
                Response.Write("<script>alert('Vui lòng nhập email')</script>");
                return View();
            }



            else
            {




                var update = db.KHACHHANGs.Find(t.MaKH);
                update.Ho = t.Ho;
                update.Tenlot = t.Tenlot;
                update.Ten = t.Ten;
                update.Email = t.Email;
                update.DiachiKH = t.DiachiKH;
                update.DienthoaiKH = t.DienthoaiKH;




                var id = db.SaveChanges();
                if (id > 0)
                {
                    return RedirectToAction("DanhSachKhachHang1");

                }
                else
                {

                    return View(t);
                }
            }

        }
    }
}