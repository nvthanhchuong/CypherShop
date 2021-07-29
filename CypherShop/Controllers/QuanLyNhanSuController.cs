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
    public class QuanLyNhanSuController : Controller
    {
        CypherShopEntities db = new CypherShopEntities();
        // GET: QuanLyNhanSu
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DanhSachNhanVien(int? page)
        {
            if (Session["Taikhoan"] != null)
            {
                int pagesize = 7;
                int pagenum = (page ?? 1);
                return View(db.NHANVIENs.ToList().OrderByDescending(n => n.MaNV).ToPagedList(pagenum, pagesize));
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
                var lstnv = db.NHANVIENs.Where(a => a.HoTen.Contains(SearchString)).ToList();
                return View(lstnv);
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }

        public ActionResult ThemNhanVien()
        {
            if (Session["Taikhoan"] != null)
            {
                ViewBag.IdChucVu = new SelectList(db.CHUCVUs.ToList().OrderBy(n => n.IdChucVu), "IdChucVu", "TenChucVu");
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }

        [HttpPost]
        public ActionResult ThemNhanVien(NHANVIEN t, HttpPostedFileBase fileupload)
        {
            ViewBag.IdChucVu = new SelectList(db.CHUCVUs.ToList().OrderBy(n => n.IdChucVu), "IdChucVu", "TenChucVu");

            if (t.HoTen == null)
            {
                Response.Write("<script>alert('Vui nhập họ tên nhân viên')</script>");
                return View();
            }
            else if (t.MaNV == null)
            {
                Response.Write("<script>alert('Vui nhập mã nhân viên')</script>");
                return View();
            }

            else if (t.Taikhoan == null)
            {
                Response.Write("<script>alert('Vui nhập tài khoản của nhân viên')</script>");
                return View();
            }

            else if (t.Matkhau == null)
            {
                Response.Write("<script>alert('Vui nhập mật khẩu của nhân viên')</script>");
                return View();
            }

            else if (t.DiachiNV == null)
            {
                Response.Write("<script>alert('Vui nhập địa chỉ của nhân viên')</script>");
                return View();
            }

            else if (t.DienthoaiNV == null)
            {
                Response.Write("<script>alert('Vui nhập số điện thoại của nhân viên')</script>");
                return View();
            }

            else if (t.Email == null)
            {
                Response.Write("<script>alert('Vui nhập email của nhân viên')</script>");
                return View();
            }

            else if (fileupload == null)
            {
                Response.Write("<script>alert('Vui lòng thêm ảnh của nhân viên')</script>");
                return View();
            }

            else if (t.Matkhau == null)
            {
                Response.Write("<script>alert('Vui lòng điền mật khẩu')</script>");
                return View();
            }

            else if (t.Nhaplaimatkhau == null)
            {
                Response.Write("<script>alert('Vui lòng nhập lại mật khẩu')</script>");
                return View();
            }

            else if (t.Matkhau.Length < 6)
            {
                Response.Write("<script>alert('Mật khẩu từ 6 kí tự trở lên')</script>");
                return View();
            }

            else if (t.Nhaplaimatkhau != t.Matkhau)
            {
                Response.Write("<script>alert('Vui lòng nhập lại mật khẩu chính xác')</script>");
                return View();
            }

            else if (db.NHANVIENs.Any(x => x.MaNV == t.MaNV))
            {
                Response.Write("<script>alert('Mã nhân viên đã tồn tại')</script>");
                return View();
            }

            else if(db.NHANVIENs.Any(x => x.Taikhoan == t.Taikhoan))
            {
                Response.Write("<script>alert('Tài khoản đã tồn tại')</script>");
                return View();
            }


            else
            {

                // Luu ten fie, luu y bo sung thu vien using System.IO;
                var fileName = Path.GetFileName(fileupload.FileName);
                //Luu duong dan cua file
                var path = Path.Combine(Server.MapPath("~/ImagesNv"), fileName);
                //Kiem tra hình anh ton tai chua?
                if (System.IO.File.Exists(path))
                    ViewBag.Thongbao = "Hình ảnh đã tồn tại";
                else
                {
                    //Luu hinh anh vao duong dan
                    fileupload.SaveAs(path);
                }
                t.Anh = fileName;


                db.NHANVIENs.Add(t);
                db.SaveChanges();
                Response.Write("<script>alert('Thêm thành công')</script>");
                ModelState.Clear();
                return View();
            }
        }

        public ActionResult XoaNhanVien(string id)
        {
            if (Session["Taikhoan"] != null)
            {
                var nv = db.NHANVIENs.Find(id);
                db.NHANVIENs.Remove(nv);
                db.SaveChanges();
                return RedirectToAction("DanhSachNhanVien", "QuanLyNhanSu");
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }

    

        public ActionResult CapNhat(string id)
        {
            if (Session["Taikhoan"] != null)
            {
                ViewBag.IdChucVu = new SelectList(db.CHUCVUs.ToList().OrderBy(n => n.IdChucVu), "IdChucVu", "TenChucVu");
                var nv = db.NHANVIENs.Find(id);
                return View(nv);
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }

        [HttpPost]
        public ActionResult CapNhat(NHANVIEN t, HttpPostedFileBase fileupload)
        {
            ViewBag.IdChucVu = new SelectList(db.CHUCVUs.ToList().OrderBy(n => n.IdChucVu), "IdChucVu", "TenChucVu");

            if (t.HoTen == null)
            {
                Response.Write("<script>alert('Vui nhập họ tên nhân viên')</script>");
                return View();
            }
            else if (t.MaNV == null)
            {
                Response.Write("<script>alert('Vui nhập mã nhân viên')</script>");
                return View();
            }

            else if (t.DiachiNV == null)
            {
                Response.Write("<script>alert('Vui nhập địa chỉ của nhân viên')</script>");
                return View();
            }

            else if (t.DienthoaiNV == null)
            {
                Response.Write("<script>alert('Vui nhập số điện thoại của nhân viên')</script>");
                return View();
            }

            else if (t.Email == null)
            {
                Response.Write("<script>alert('Vui nhập email của nhân viên')</script>");
                return View();
            }

            else if (fileupload == null)
            {
                Response.Write("<script>alert('Vui lòng thêm ảnh của nhân viên')</script>");
                return View();
            }

            else
            {

                // Luu ten fie, luu y bo sung thu vien using System.IO;
                var fileName = Path.GetFileName(fileupload.FileName);
                //Luu duong dan cua file
                var path = Path.Combine(Server.MapPath("~/ImagesNv"), fileName);
                //Kiem tra hình anh ton tai chua?
                if (System.IO.File.Exists(path))
                    ViewBag.Thongbao = "Hình ảnh đã tồn tại";
                else
                {
                    //Luu hinh anh vao duong dan
                    fileupload.SaveAs(path);
                }
                t.Anh = fileName;


                var update = db.NHANVIENs.Find(t.MaNV);
                update.HoTen = t.HoTen;
                update.IdChucVu = t.IdChucVu;
                update.Ngaysinh = t.Ngaysinh;
                update.DiachiNV = t.DiachiNV;
                update.DienthoaiNV = t.DienthoaiNV;
                update.Anh = t.Anh;
                update.Email = t.Email;

                var id = db.SaveChanges();
                if (id > 0)
                {
                    return RedirectToAction("DanhSachNhanVien");
                }
                else
                {

                    return View(t);
                }

            }


        }
    }
}