using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CypherShop.Models;
using PagedList;
using PagedList.Mvc;

namespace CypherShop.Controllers
{
    public class NhaSanXuatController : Controller
    {
        // GET: NhaSanXuat
        CypherShopEntities db = new CypherShopEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DanhSachNSX(int? page)
        {
            if (Session["Taikhoan"] != null)
            {

                int pagesize = 7;
                int pagenum = (page ?? 1);
                return View(db.NHASANXUATs.ToList().OrderByDescending(n => n.MaNSX).ToPagedList(pagenum, pagesize));

            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }

        public ActionResult DanhSachNSX1(int? page)
        {
            if (Session["Taikhoan"] != null)
            {
                int pagesize = 7;
                int pagenum = (page ?? 1);
                return View(db.NHASANXUATs.ToList().OrderByDescending(n => n.MaNSX).ToPagedList(pagenum, pagesize));
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
                var lstsp = db.NHASANXUATs.Where(a => a.TenNSX.Contains(SearchString)).ToList();
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
                var lstsp = db.NHASANXUATs.Where(a => a.TenNSX.Contains(SearchString)).ToList();
                return View(lstsp);
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }

        public ActionResult XoaNSX(int id)
        {
            if (Session["Taikhoan"] != null)
            {
                var sp = db.NHASANXUATs.Find(id);
                db.NHASANXUATs.Remove(sp);
                db.SaveChanges();
                return RedirectToAction("DanhSachNSX", "NhaSanXuat");
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }

        public ActionResult XoaNSX1(int id)
        {
            if (Session["Taikhoan"] != null)
            {
                var sp = db.NHASANXUATs.Find(id);
                db.NHASANXUATs.Remove(sp);
                db.SaveChanges();
                return RedirectToAction("DanhSachNSX1", "NhaSanXuat");
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }

        public ActionResult ThemNSX()
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
        public ActionResult ThemNSX(NHASANXUAT t)
        {

            if (t.TenNSX == null)
            {
                Response.Write("<script>alert('Vui lòng nhập tên nsx')</script>");
                return View();
            }

            else if (t.DienThoai == null)
            {
                Response.Write("<script>alert('Vui nhập sđt')</script>");
                return View();
            }

            else if (t.Diachi == null)
            {
                Response.Write("<script>alert('Vui lòng nhập địa chỉ')</script>");
                return View();
            }

            else if (t.Email == null)
            {
                Response.Write("<script>alert('Vui lòng nhập email')</script>");
                return View();
            }

            else if (db.NHASANXUATs.Any(x => x.TenNSX == t.TenNSX))
            {
                Response.Write("<script>alert('Nhà sản xuất đã tồn tại')</script>");
                return View();
            }

            else
            {

                

                db.NHASANXUATs.Add(t);
                db.SaveChanges();
                Response.Write("<script>alert('Thêm thành công')</script>");
                ModelState.Clear();

                return View();
            }
        }

        public ActionResult ThemNSX1()
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
        public ActionResult ThemNSX1(NHASANXUAT t)
        {

            if (t.TenNSX == null)
            {
                Response.Write("<script>alert('Vui lòng nhập tên nsx')</script>");
                return View();
            }

            else if (t.DienThoai == null)
            {
                Response.Write("<script>alert('Vui nhập sđt')</script>");
                return View();
            }

            else if (t.Diachi == null)
            {
                Response.Write("<script>alert('Vui lòng nhập địa chỉ')</script>");
                return View();
            }

            else if (t.Email == null)
            {
                Response.Write("<script>alert('Vui lòng nhập email')</script>");
                return View();
            }

            else if (db.NHASANXUATs.Any(x => x.TenNSX == t.TenNSX))
            {
                Response.Write("<script>alert('Nhà sản xuất đã tồn tại')</script>");
                return View();
            }

            else
            {



                db.NHASANXUATs.Add(t);
                db.SaveChanges();
                Response.Write("<script>alert('Thêm thành công')</script>");
                ModelState.Clear();

                return View();
            }
        }

        public ActionResult CapNhat(int id)
        {
            if (Session["Taikhoan"] != null)
            {
                
                var sp = db.NHASANXUATs.Find(id);
                return View(sp);
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }

        [HttpPost]
        public ActionResult CapNhat(NHASANXUAT t)
        {


            if (t.TenNSX == null)
            {
                Response.Write("<script>alert('Vui lòng nhập tên nhà sản xuất')</script>");
                return View();
            }
            else if (db.NHASANXUATs.Any(x => x.TenNSX == t.TenNSX))
            {
                Response.Write("<script>alert('Nhà sản xuất đã tồn tại')</script>");
                return View();
            }

            else if (t.Diachi == null)
            {
                Response.Write("<script>alert('Vui lòng nhập địa chỉ')</script>");
                return View();
            }

            else if (t.DienThoai == null)
            {
                Response.Write("<script>alert('Vui lòng nhập sđt')</script>");
                return View();
            }
            else if (t.Email == null)
            {
                Response.Write("<script>alert('Vui lòng nhập email')</script>");
                return View();
            }

            else
            {

                var update = db.NHASANXUATs.Find(t.MaNSX);
                update.TenNSX = t.TenNSX;
                update.DienThoai = t.DienThoai;
                update.Diachi = t.Diachi;
                update.Email = t.Email;



                var id = db.SaveChanges();
                if (id > 0)
                {
                    return RedirectToAction("DanhSachNSX");

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

                var sp = db.NHASANXUATs.Find(id);
                return View(sp);
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }

        [HttpPost]
        public ActionResult CapNhat1(NHASANXUAT t)
        {


            if (t.TenNSX == null)
            {
                Response.Write("<script>alert('Vui lòng nhập tên nhà sản xuất')</script>");
                return View();
            }
            else if (db.NHASANXUATs.Any(x => x.TenNSX == t.TenNSX))
            {
                Response.Write("<script>alert('Nhà sản xuất đã tồn tại')</script>");
                return View();
            }

            else if (t.Diachi == null)
            {
                Response.Write("<script>alert('Vui lòng nhập địa chỉ')</script>");
                return View();
            }

            else if (t.DienThoai == null)
            {
                Response.Write("<script>alert('Vui lòng nhập sđt')</script>");
                return View();
            }
            else if (t.Email == null)
            {
                Response.Write("<script>alert('Vui lòng nhập email')</script>");
                return View();
            }

            else
            {


                var update = db.NHASANXUATs.Find(t.MaNSX);
                update.TenNSX = t.TenNSX;
                update.DienThoai = t.DienThoai;
                update.Diachi = t.Diachi;
                update.Email = t.Email;



                var id = db.SaveChanges();
                if (id > 0)
                {
                    return RedirectToAction("DanhSachNSX1");

                }
                else
                {

                    return View(t);
                }
            }
        }
    }
}