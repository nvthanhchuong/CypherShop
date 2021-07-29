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
    public class QuanLySanPhamController : Controller
    {
        // GET: QuanLySanPham

        CypherShopEntities db = new CypherShopEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DanhSachSanPham(int? page)
        {
            if (Session["Taikhoan"] != null)
            {

                int pagesize = 7;
                int pagenum = (page ?? 1);
                return View(db.SANPHAMs.ToList().OrderByDescending(n => n.MaSP).ToPagedList(pagenum, pagesize));

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
                var lstsp = db.SANPHAMs.Where(a => a.TenSP.Contains(SearchString)).ToList();
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
                var lstsp = db.SANPHAMs.Where(a => a.TenSP.Contains(SearchString)).ToList();
                return View(lstsp);
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }
        public ActionResult DanhSachSanPham1(int? page)
        {
            if (Session["Taikhoan"] != null)
            {
                int pagesize = 7;
                int pagenum = (page ?? 1);
                return View(db.SANPHAMs.ToList().OrderByDescending(n => n.MaSP).ToPagedList(pagenum, pagesize));
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }
        public ActionResult ThemSanPham()
        {
            if (Session["Taikhoan"] != null)
            {
                ViewBag.MaTL = new SelectList(db.THELOAIs.ToList().OrderBy(n => n.TenTheLoai), "MaTl", "TenTheLoai");
                ViewBag.MaNSX = new SelectList(db.NHASANXUATs.ToList().OrderBy(n => n.TenNSX), "MaNSX", "TenNSX");
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }

        [HttpPost]
        public ActionResult ThemSanPham(SANPHAM t, HttpPostedFileBase fileupload)
        {
            ViewBag.MaTL = new SelectList(db.THELOAIs.ToList().OrderBy(n => n.TenTheLoai), "MaTl", "TenTheLoai");
            ViewBag.MaNSX = new SelectList(db.NHASANXUATs.ToList().OrderBy(n => n.TenNSX), "MaNSX", "TenNSX");

            if (t.TenSP == null)
            {
                Response.Write("<script>alert('Vui lòng nhập tên sản phẩm')</script>");
                return View();
            }

            else if (t.Giaban == null)
            {
                Response.Write("<script>alert('Vui nhập giá bán')</script>");
                return View();
            }

            else if (t.Ngaycapnhat == null)
            {
                Response.Write("<script>alert('Vui nhập ngày')</script>");
                return View();
            }

            else if (t.Soluongton == null)
            {
                Response.Write("<script>alert('Vui nhập số lượng')</script>");
                return View();
            }


            else if (fileupload == null)
            {
                Response.Write("<script>alert('Vui lòng chọn ảnh bìa')</script>");
                return View();
            }

            else
            {

                //Luu ten fie, luu y bo sung thu vien using System.IO;
                var fileName = Path.GetFileName(fileupload.FileName);
                //Luu duong dan cua file
                var path = Path.Combine(Server.MapPath("~/Images"), fileName);
                //Kiem tra hình anh ton tai chua?
                if (System.IO.File.Exists(path))
                    ViewBag.Thongbao = "Hình ảnh đã tồn tại";
                else
                {
                    //Luu hinh anh vao duong dan
                    fileupload.SaveAs(path);
                }

                t.Anhbia = fileName;

                db.SANPHAMs.Add(t);
                db.SaveChanges();
                Response.Write("<script>alert('Thêm thành công')</script>");
                ModelState.Clear();

                return View();
            }
        }

        public ActionResult ThemSanPham1()
        {
            if (Session["Taikhoan"] != null)
            {
                ViewBag.MaTL = new SelectList(db.THELOAIs.ToList().OrderBy(n => n.TenTheLoai), "MaTl", "TenTheLoai");
                ViewBag.MaNSX = new SelectList(db.NHASANXUATs.ToList().OrderBy(n => n.TenNSX), "MaNSX", "TenNSX");
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }

        [HttpPost]
        public ActionResult ThemSanPham1(SANPHAM t, HttpPostedFileBase fileupload)
        {
            ViewBag.MaTL = new SelectList(db.THELOAIs.ToList().OrderBy(n => n.TenTheLoai), "MaTl", "TenTheLoai");
            ViewBag.MaNSX = new SelectList(db.NHASANXUATs.ToList().OrderBy(n => n.TenNSX), "MaNSX", "TenNSX");

            if (t.TenSP == null)
            {
                Response.Write("<script>alert('Vui lòng nhập tên sản phẩm')</script>");
                return View();
            }

            else if (t.Giaban == null)
            {
                Response.Write("<script>alert('Vui nhập giá bán')</script>");
                return View();
            }

            else if (t.Ngaycapnhat == null)
            {
                Response.Write("<script>alert('Vui nhập ngày')</script>");
                return View();
            }

            else if (t.Soluongton == null)
            {
                Response.Write("<script>alert('Vui nhập số lượng')</script>");
                return View();
            }


            else if (fileupload == null)
            {
                Response.Write("<script>alert('Vui lòng chọn ảnh bìa')</script>");
                return View();
            }

            else
            {

                //Luu ten fie, luu y bo sung thu vien using System.IO;
                var fileName = Path.GetFileName(fileupload.FileName);
                //Luu duong dan cua file
                var path = Path.Combine(Server.MapPath("~/Images"), fileName);
                //Kiem tra hình anh ton tai chua?
                if (System.IO.File.Exists(path))
                    ViewBag.Thongbao = "Hình ảnh đã tồn tại";
                else
                {
                    //Luu hinh anh vao duong dan
                    fileupload.SaveAs(path);
                }

                t.Anhbia = fileName;

                db.SANPHAMs.Add(t);
                db.SaveChanges();
                Response.Write("<script>alert('Thêm thành công')</script>");
                ModelState.Clear();

                return View();
            }
        }

        public ActionResult XoaSanPham(int id)
        {
            if (Session["Taikhoan"] != null)
            {
                var sp = db.SANPHAMs.Find(id);
                db.SANPHAMs.Remove(sp);
                db.SaveChanges();
                return RedirectToAction("DanhSachSanPham", "QuanLySanPham");
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }

        public ActionResult XoaSanPham1(int id)
        {
            if (Session["Taikhoan"] != null)
            {
                var sp = db.SANPHAMs.Find(id);
                db.SANPHAMs.Remove(sp);
                db.SaveChanges();
                return RedirectToAction("DanhSachSanPham1", "QuanLySanPham");
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
                ViewBag.MaTL = new SelectList(db.THELOAIs.ToList().OrderBy(n => n.TenTheLoai), "MaTl", "TenTheLoai");
                ViewBag.MaNSX = new SelectList(db.NHASANXUATs.ToList().OrderBy(n => n.TenNSX), "MaNSX", "TenNSX");
                var sp = db.SANPHAMs.Find(id);
                return View(sp);
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }

        [HttpPost]
        public ActionResult CapNhat(SANPHAM t, HttpPostedFileBase fileupload)
        {
            ViewBag.MaTL = new SelectList(db.THELOAIs.ToList().OrderBy(n => n.TenTheLoai), "MaTl", "TenTheLoai");
            ViewBag.MaNSX = new SelectList(db.NHASANXUATs.ToList().OrderBy(n => n.TenNSX), "MaNSX", "TenNSX");

            if (t.TenSP == null)
            {
                Response.Write("<script>alert('Vui lòng nhập tên sản phẩm')</script>");
                return View();
            }

            else if (t.Giaban == null)
            {
                Response.Write("<script>alert('Vui nhập giá bán')</script>");
                return View();
            }

            else if (t.Ngaycapnhat == null)
            {
                Response.Write("<script>alert('Vui nhập ngày')</script>");
                return View();
            }

            else if (t.Soluongton == null)
            {
                Response.Write("<script>alert('Vui nhập số lượng')</script>");
                return View();
            }

            else if (fileupload == null)
            {
                Response.Write("<script>alert('Vui lòng chọn ảnh bìa')</script>");
                return View();
            }

            else
            {

                //Luu ten fie, luu y bo sung thu vien using System.IO;
                var fileName = Path.GetFileName(fileupload.FileName);
                //Luu duong dan cua file
                var path = Path.Combine(Server.MapPath("~/Images"), fileName);
                //Kiem tra hình anh ton tai chua?
                if (System.IO.File.Exists(path))
                    ViewBag.Thongbao = "Hình ảnh đã tồn tại";
                else
                {
                    //Luu hinh anh vao duong dan
                    fileupload.SaveAs(path);
                }

                t.Anhbia = fileName;


                var update = db.SANPHAMs.Find(t.MaSP);
                update.TenSP = t.TenSP;
                update.Mota = t.Mota;
                update.Giaban = t.Giaban;
                update.Giamgia = t.Giamgia;
                update.MaTL = t.MaTL;
                update.MaNSX = t.MaNSX;
                update.Ngaycapnhat = t.Ngaycapnhat;
                update.Soluongton = t.Soluongton;
                update.Anhbia = t.Anhbia;
                update.Gianhap = t.Gianhap;             
                update.RAM = t.RAM;
                update.MauSac = t.MauSac;
                update.CPU = t.CPU;
                update.ManHinh = t.ManHinh;
                update.SCPU = t.SCPU;
                update.Trongluong = t.Trongluong;
                update.SSD = t.SSD;
                update.PhanGiai = t.PhanGiai;
                update.HDH = t.HDH;
                update.CamUng = t.CamUng;


                var id = db.SaveChanges();
                if (id > 0)
                {
                    return RedirectToAction("DanhSachSanPham");

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
                ViewBag.MaTL = new SelectList(db.THELOAIs.ToList().OrderBy(n => n.TenTheLoai), "MaTl", "TenTheLoai");
                ViewBag.MaNSX = new SelectList(db.NHASANXUATs.ToList().OrderBy(n => n.TenNSX), "MaNSX", "TenNSX");
                var sp = db.SANPHAMs.Find(id);
                return View(sp);
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }

        [HttpPost]
        public ActionResult CapNhat1(SANPHAM t, HttpPostedFileBase fileupload)
        {
            ViewBag.MaTL = new SelectList(db.THELOAIs.ToList().OrderBy(n => n.TenTheLoai), "MaTl", "TenTheLoai");
            ViewBag.MaNSX = new SelectList(db.NHASANXUATs.ToList().OrderBy(n => n.TenNSX), "MaNSX", "TenNSX");

            if (t.TenSP == null)
            {
                Response.Write("<script>alert('Vui lòng nhập tên sản phẩm')</script>");
                return View();
            }

            else if (t.Giaban == null)
            {
                Response.Write("<script>alert('Vui nhập giá bán')</script>");
                return View();
            }

            else if (t.Ngaycapnhat == null)
            {
                Response.Write("<script>alert('Vui nhập ngày')</script>");
                return View();
            }

            else if (t.Soluongton == null)
            {
                Response.Write("<script>alert('Vui nhập số lượng')</script>");
                return View();
            }

            else if (fileupload == null)
            {
                Response.Write("<script>alert('Vui lòng chọn ảnh bìa')</script>");
                return View();
            }

            else
            {

                //Luu ten fie, luu y bo sung thu vien using System.IO;
                var fileName = Path.GetFileName(fileupload.FileName);
                //Luu duong dan cua file
                var path = Path.Combine(Server.MapPath("~/Images"), fileName);
                //Kiem tra hình anh ton tai chua?
                if (System.IO.File.Exists(path))
                    ViewBag.Thongbao = "Hình ảnh đã tồn tại";
                else
                {
                    //Luu hinh anh vao duong dan
                    fileupload.SaveAs(path);
                }

                t.Anhbia = fileName;

                var update = db.SANPHAMs.Find(t.MaSP);
                update.TenSP = t.TenSP;
                update.Mota = t.Mota;
                update.Giaban = t.Giaban;
                update.Giamgia = t.Giamgia;
                update.MaTL = t.MaTL;
                update.MaNSX = t.MaNSX;
                update.Ngaycapnhat = t.Ngaycapnhat;
                update.Soluongton = t.Soluongton;
                update.Anhbia = t.Anhbia;
                update.Gianhap = t.Gianhap;
                update.RAM = t.RAM;
                update.MauSac = t.MauSac;
                update.CPU = t.CPU;
                update.ManHinh = t.ManHinh;
                update.SCPU = t.SCPU;
                update.Trongluong = t.Trongluong;
                update.SSD = t.SSD;
                update.PhanGiai = t.PhanGiai;
                update.HDH = t.HDH;
                update.CamUng = t.CamUng;

                var id = db.SaveChanges();
                if (id > 0)
                {
                    return RedirectToAction("DanhSachSanPham1");

                }
                else
                {

                    return View(t);
                }
            }

        }

    }
}