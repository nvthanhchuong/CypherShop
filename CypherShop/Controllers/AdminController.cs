using CypherShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CypherShop.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        CypherShopEntities db = new CypherShopEntities();
        // GET: Admin

        public ActionResult Index()
        {
            if (Session["Taikhoan"] != null)
                return View();
            else
                return RedirectToAction("Login", "Admin");
        }


        public ActionResult Index1()
        {
            if (Session["Taikhoan"] != null)
                return View();
            else
                return RedirectToAction("Login", "Admin");
        }
        public ActionResult Login()
        {
            return View();

        }

        [HttpPost]
        public ActionResult Login(NHANVIEN t)
        {

            var lg = db.NHANVIENs.Where(a => a.Taikhoan.Equals(t.Taikhoan) && a.Matkhau.Equals(t.Matkhau)).FirstOrDefault();
            if (lg != null && lg.IdChucVu == 3)
            {
                Session["Taikhoan"] = lg.Taikhoan;
                return RedirectToAction("Index1", "Admin");

            }
            else if (lg != null && (lg.IdChucVu == 1 || lg.IdChucVu == 2))
            {
                Session["Taikhoan"] = lg.Taikhoan;
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                Response.Write("<script>alert('Vui lòng kiểm tra tên đăng nhập hoặc nật khẩu')</script>");
                ModelState.Clear();
                return View();
            }
        }
    }
}