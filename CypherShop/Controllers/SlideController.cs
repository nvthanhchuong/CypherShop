using CypherShop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CypherShop.Controllers
{
    public class SlideController : Controller
    {
        CypherShopEntities db = new CypherShopEntities();
        // GET: Slide
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Slide()
        {
            var lstslide = db.Slides.ToList();
            ProductDetail objpro = new ProductDetail();
            objpro.ListSlide = lstslide;
            return PartialView(objpro);
        }

        public ActionResult DanhSachSlide()
        {
            if (Session["Taikhoan"] != null)
            {
                var lstslide = db.Slides.ToList();
                return View(lstslide);
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }

        public ActionResult DanhSachSlide1()
        {
            if (Session["Taikhoan"] != null)
            {
                var lstslide = db.Slides.ToList();
                return View(lstslide);
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }
        public ActionResult ThemSlide()
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
        public ActionResult ThemSlide(Slide t, HttpPostedFileBase fileupload)
        {

            if (fileupload == null)
            {
                Response.Write("<script>alert('Vui lòng chọn ảnh bìa')</script>");
                return View();
            }

            else
            {

                // Luu ten fie, luu y bo sung thu vien using System.IO;
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
                t.Anh = fileName;


                db.Slides.Add(t);
                db.SaveChanges();
                Response.Write("<script>alert('Thêm thành công')</script>");
                ModelState.Clear();
                return View();
            }
        }

        public ActionResult ThemSlide1()
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
        public ActionResult ThemSlide1(Slide t, HttpPostedFileBase fileupload)
        {

            if (fileupload == null)
            {
                Response.Write("<script>alert('Vui lòng chọn ảnh bìa')</script>");
                return View();
            }

            else
            {

                // Luu ten fie, luu y bo sung thu vien using System.IO;
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
                t.Anh = fileName;


                db.Slides.Add(t);
                db.SaveChanges();
                Response.Write("<script>alert('Thêm thành công')</script>");
                ModelState.Clear();
                return View();
            }
        }

        public ActionResult XoaSlide(int id)
        {
            if (Session["Taikhoan"] != null)
            {
                var nv = db.Slides.Find(id);
                db.Slides.Remove(nv);
                db.SaveChanges();
                return RedirectToAction("DanhSachSlide", "Slide");
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }

        public ActionResult XoaSlide1(int id)
        {
            if (Session["Taikhoan"] != null)
            {
                var nv = db.Slides.Find(id);
                db.Slides.Remove(nv);
                db.SaveChanges();
                return RedirectToAction("DanhSachSlide1", "Slide");
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

                var sp = db.Slides.Find(id);
                return View(sp);
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }

        [HttpPost]
        public ActionResult CapNhat(Slide t, HttpPostedFileBase fileupload)
        {



            if (fileupload == null)
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

                t.Anh = fileName;


                var update = db.Slides.Find(t.Id);
                update.Anh = t.Anh;



                var id = db.SaveChanges();
                if (id > 0)
                {
                    return RedirectToAction("DanhSachSlide");

                }
                else
                {

                    return View(t);
                }
            }

        }

        public ActionResult Capnhat1(int id)
        {
            if (Session["Taikhoan"] != null)
            {
                var sp = db.Slides.Find(id);
                return View(sp);
               
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }

        [HttpPost]
        public ActionResult CapNhat1(Slide t, HttpPostedFileBase fileupload)
        {

            if (fileupload == null)
            {
                Response.Write("<script>alert('Vui lòng chọn ảnh bìa')</script>");
                return View();
            }

            else
            {

                // Luu ten fie, luu y bo sung thu vien using System.IO;
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
                t.Anh = fileName;


                var update = db.Slides.Find(t.Id);
                update.Anh = t.Anh;




                var id = db.SaveChanges();
                if (id > 0)
                {
                    return RedirectToAction("DanhSachSlide");

                }
                else
                {

                    return View(t);
                }
            }

        }
    }
}
    