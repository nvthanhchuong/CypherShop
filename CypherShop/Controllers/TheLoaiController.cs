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
    public class TheLoaiController : Controller
    {
        // GET: TheLoai
        CypherShopEntities db = new CypherShopEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DanhSachTheLoai(int? page)
        {
            if (Session["Taikhoan"] != null)
            {

                int pagesize = 7;
                int pagenum = (page ?? 1);
                return View(db.THELOAIs.ToList().OrderByDescending(n => n.MaTL).ToPagedList(pagenum, pagesize));

            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }

        public ActionResult DanhSachTheLoai1(int? page)
        {
            if (Session["Taikhoan"] != null)
            {
                int pagesize = 7;
                int pagenum = (page ?? 1);
                return View(db.THELOAIs.ToList().OrderByDescending(n => n.MaTL).ToPagedList(pagenum, pagesize));
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
                var lstsp = db.THELOAIs.Where(a => a.TenTheLoai.Contains(SearchString)).ToList();
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
                var lstsp = db.THELOAIs.Where(a => a.TenTheLoai.Contains(SearchString)).ToList();
                return View(lstsp);
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }

        public ActionResult XoaTheLoai(int id)
        {
            if (Session["Taikhoan"] != null)
            {
                var sp = db.THELOAIs.Find(id);
                db.THELOAIs.Remove(sp);
                db.SaveChanges();
                return RedirectToAction("DanhSachTheLoai", "TheLoai");
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }

        public ActionResult XoaTheLoai1(int id)
        {
            if (Session["Taikhoan"] != null)
            {
                var sp = db.THELOAIs.Find(id);
                db.THELOAIs.Remove(sp);
                db.SaveChanges();
                return RedirectToAction("DanhSachTheLoai1", "TheLoai");
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }

        public ActionResult ThemTheLoai()
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
        public ActionResult ThemTheLoai(THELOAI t)
        {

            if (t.TenTheLoai == null)
            {
                Response.Write("<script>alert('Vui lòng nhập tên thể loại')</script>");
                return View();
            }

            else if (db.THELOAIs.Any(x => x.TenTheLoai == t.TenTheLoai))
            {
                Response.Write("<script>alert('Thể loại đã tồn tại')</script>");
                return View();
            }

            else
            {



                db.THELOAIs.Add(t);
                db.SaveChanges();
                Response.Write("<script>alert('Thêm thành công')</script>");
                ModelState.Clear();

                return View();
            }
        }
        public ActionResult ThemTheLoai1()
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
        public ActionResult ThemTheLoai1(THELOAI t)
        {

            if (t.TenTheLoai == null)
            {
                Response.Write("<script>alert('Vui lòng nhập tên thể loại')</script>");
                return View();
            }

            else if (db.THELOAIs.Any(x => x.TenTheLoai == t.TenTheLoai))
            {
                Response.Write("<script>alert('Thể loại đã tồn tại')</script>");
                return View();
            }

            else
            {



                db.THELOAIs.Add(t);
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

                var sp = db.THELOAIs.Find(id);
                return View(sp);
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }

        [HttpPost]
        public ActionResult CapNhat(THELOAI t)
        {


            if (t.TenTheLoai == null)
            {
                Response.Write("<script>alert('Vui lòng nhập tên thể loại')</script>");
                return View();
            }
            else if (db.THELOAIs.Any(x => x.TenTheLoai == t.TenTheLoai))
            {
                Response.Write("<script>alert('Thể loại đã tồn tại')</script>");
                return View();
            }


            else
            {

                var update = db.THELOAIs.Find(t.MaTL);
                update.TenTheLoai = t.TenTheLoai;
               



                var id = db.SaveChanges();
                if (id > 0)
                {
                    return RedirectToAction("DanhSachTheLoai");

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

                var sp = db.THELOAIs.Find(id);
                return View(sp);
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }

        [HttpPost]
        public ActionResult CapNhat1(THELOAI t)
        {


            if (t.TenTheLoai == null)
            {
                Response.Write("<script>alert('Vui lòng nhập tên thể loại')</script>");
                return View();
            }
            else if (db.THELOAIs.Any(x => x.TenTheLoai == t.TenTheLoai))
            {
                Response.Write("<script>alert('Thể loại đã tồn tại')</script>");
                return View();
            }


            else
            {

                var update = db.THELOAIs.Find(t.MaTL);
                update.TenTheLoai = t.TenTheLoai;




                var id = db.SaveChanges();
                if (id > 0)
                {
                    return RedirectToAction("DanhSachTheLoai1");

                }
                else
                {

                    return View(t);
                }
            }
        }

    }
}