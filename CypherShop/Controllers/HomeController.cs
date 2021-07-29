using CypherShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using Facebook;
using System.Configuration;

namespace CypherShop.Controllers
{
    public class HomeController : Controller
    {
        CypherShopEntities db = new CypherShopEntities();

        [HttpGet]
        public JsonResult Get()
        {
            return Json("fsdfsdfd", JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index(int? page)
        {

            if (page == null) page = 1;
                var SANPHAM = (from l in db.SANPHAMs select l).OrderBy(x => x.MaSP);

                int pageSize = 15;

                int pageNumber = (page ?? 1);
            return View(SANPHAM.ToPagedList(pageNumber, pageSize));
    }
        public ActionResult ProductsCategory()
        {
            var listTheLoai = db.THELOAIs.ToList();
            ProductDetail pro = new ProductDetail();
            pro.ListTheLoai = listTheLoai;
          
            return PartialView(pro);
        }
        public ActionResult Tabpanel()
        {
            var listSanPham = db.SANPHAMs.ToList();

            ProductDetail pro = new ProductDetail();
            pro.ListSanPham = listSanPham;

            return PartialView(pro);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Registrator()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registrator(KHACHHANG t)
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
                Response.Write("<script>alert('Đăng kí thành công')</script>");
                return View();

            }

        }

        [HttpGet]
        public ActionResult ChangePassword()
        {

            return View();
        }

        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            var lg = db.KHACHHANGs.Where(a => a.Taikhoan.Equals(model.Taikhoan) && a.Matkhau.Equals(model.Matkhaucu)).FirstOrDefault();
            if (lg != null)
            {
                if (model.Matkhaumoi == lg.Matkhau)
                {
                    Response.Write("<script>alert('Mật khẩu mới không được trùng với mật khẩu cũ')</script>");
                    ModelState.Clear();
                    return View();
                }

                else if (model.Matkhaumoi == null)
                {
                    Response.Write("<script>alert('Vui lòng nhập mật khẩu mới')</script>");
                    ModelState.Clear();
                    return View();
                }
                else if (model.Matkhaumoi.Length < 6)
                {
                    Response.Write("<script>alert('Mật khẩu từ 6 kí tự trở lên')</script>");
                    ModelState.Clear();
                    return View();
                }
                else if (model.Matkhaumoi == null)
                {
                    Response.Write("<script>alert('Vui lòng nhập lại mật khẩu mới')</script>");
                    ModelState.Clear();
                    return View();
                }
                else if (model.Matkhaumoi != model.Nhaplaimatkhau)
                {
                    Response.Write("<script>alert('Vui lòng nhập lại chính xác mật khẩu mới')</script>");
                    ModelState.Clear();
                    return View();
                }
                else
                {
                    lg.Matkhau = model.Matkhaumoi;
                    db.SaveChanges();
                    Response.Write("<script>alert('Đổi mật khẩu thành công')</script>");
                    ModelState.Clear();
                    return View();
                }
            }
            else
            {
                Response.Write("<script>alert('Vui lòng nhập đúng tên đăng nhập và mật khẩu')</script>");
                ModelState.Clear();
                return View();
            }
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(KHACHHANG t)
        {

            var lg = db.KHACHHANGs.Where(a => a.Taikhoan.Equals(t.Taikhoan) && a.Matkhau.Equals(t.Matkhau)).FirstOrDefault();
            if (lg != null)
            {
                Session["users"] = lg;
                Session["user"] = lg.Taikhoan;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                Response.Write("<script>alert('Vui lòng kiểm tra tên đăng nhập hoặc mật khẩu')</script>");
                return View();
            }

        }

        private Uri RedirectUri
        {
            get
            {
                var uriBuilder = new UriBuilder(Request.Url);
                uriBuilder.Query = null;
                uriBuilder.Fragment = null;
                uriBuilder.Path = Url.Action("FacebookCallback");
                return uriBuilder.Uri;
            }
        }
        public ActionResult LoginFacebook()
        {
            var fb = new FacebookClient();
            var loginUrl = fb.GetLoginUrl(new
            {
                client_id = ConfigurationManager.AppSettings["FbAppId"],
                client_secret = ConfigurationManager.AppSettings["FbAppSecret"],
                redirect_uri = RedirectUri.AbsoluteUri,
                response_type = "code",
                scope = "email",
            });

            return Redirect(loginUrl.AbsoluteUri);
        }

        public ActionResult FacebookCallback(string code)
        {
            var fb = new FacebookClient();
            dynamic result = fb.Post("oauth/access_token", new
            {
                client_id = ConfigurationManager.AppSettings["FbAppId"],
                client_secret = ConfigurationManager.AppSettings["FbAppSecret"],
                redirect_uri = RedirectUri.AbsoluteUri,
                code = code
            });

            var accessToken = result.access_token;

            if (!string.IsNullOrEmpty(accessToken))
            {
                fb.AccessToken = accessToken;
                dynamic me = fb.Get("me?fields=first_name,middle_name,last_name,id,email");
                string email = me.email;
                string username = me.email;
                string firstname = me.first_name;
                string middlename = me.middle_name;
                string lastname = me.last_name;


                var user = new KHACHHANG();
                user.Email = email;
                user.Taikhoan = username;
                user.Ho = firstname;
                user.Tenlot = middlename;
                user.Ten = lastname;

                Session["user"] = user.Ho + " " + user.Tenlot + " " + user.Ten;
            }
            else
            {

            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult LogOut()
        {
            Session["user"] = null;
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Timkiem(string SearchString)
        {
            var lstSanPham = db.SANPHAMs.Where(n => n.TenSP.Contains(SearchString)).ToList();
            return View(lstSanPham);
        }
    }
}
    
