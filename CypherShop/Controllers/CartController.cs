using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CypherShop.Models;
namespace WebsiteBanHang.Controllers
{
    public class CartController : Controller
    {
        CypherShopEntities db = new CypherShopEntities();
        // GET: Cart

        public List<Cart> Laygiohang()
        {
            List<Cart> listGiohang = Session["Cart"] as List<Cart>;
            if (listGiohang == null)
            {
                listGiohang = new List<Cart>();
                Session["Cart"] = listGiohang;
            }
            return listGiohang;
        }
        public ActionResult ThemGioHang(int iMaSP, string strURL)
        {
            List<Cart> listGioHang = Laygiohang();
            Cart sanpham = listGioHang.Find(n => n.iMaSP == iMaSP);
            if (sanpham == null)
            {
                sanpham = new Cart(iMaSP);
                listGioHang.Add(sanpham);
                return Redirect(strURL);
            }
            else
            {
                sanpham.iSoluong++;
                return Redirect(strURL);
            }

        }
        //phương thức tính tổng số lượng
        private int TongSoLuong()
        {
            int iTongSoLuong = 0;
            List<Cart> listGiohang = Session["Cart"] as List<Cart>;
            if (listGiohang != null)
            {
                iTongSoLuong = listGiohang.Sum(n => n.iSoluong);
            }
            return iTongSoLuong;
        }
        //phuong thức tính tổng tiền
        private double TongTien()
        {
            double iTongTien = 0;
            List<Cart> listGiohang = Session["Cart"] as List<Cart>;
            if (listGiohang != null)
            {
                iTongTien = listGiohang.Sum(n => n.dThanhtien);
            }
            return iTongTien;
        }
        // Phương thức hiển thị xử lí giỏ hàng
        public ActionResult Giohang()
        {
            List<Cart> listGiohang = Laygiohang();
            if (listGiohang.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.TongSoluong = TongSoLuong();
            ViewBag.TongTien = TongTien();
            return View(listGiohang);

        }

        // GET: Giohang
        public ActionResult GiohangPartial()
        {
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongTien = TongTien();
            return PartialView();
        }
        //xoá giỏ hàng
        public ActionResult XoaGioHang(int iMasp)
        {
            List<Cart> listGiohang = Laygiohang();

            Cart sanpham = listGiohang.SingleOrDefault(n => n.iMaSP == iMasp);
            if (sanpham != null)
            {
                listGiohang.RemoveAll(n => n.iMaSP == iMasp);
                return RedirectToAction("Giohang");

            }
            if (listGiohang.Count == 0)
            {
                return RedirectToAction("Index", "Books");
            }
            return RedirectToAction("Giohang");
        }
        //cap nhật giỏ hàng
        public ActionResult CapNhatGioHang(int iMaSp, FormCollection f)
        {
            List<Cart> listGiohang = Laygiohang();
            Cart sanpham = listGiohang.SingleOrDefault(n => n.iMaSP == iMaSp);
            if (sanpham != null)
            {
                sanpham.iSoluong = int.Parse(f["txtsoluong"].ToString());
            }
            return RedirectToAction("Giohang");
        }
        //xoa tat ca gio hang
        public ActionResult XoaTatCaGioHang()
        {
            // lấy giỏ hàng từ session
            List<Cart> listGiohang = Laygiohang();
            listGiohang.Clear();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public ActionResult Order()
        {
            //Kt đăng nhập
            if (Session["user"] == null || Session["user"].ToString() == "")
            {
                return RedirectToAction("Login", "Home");
            }    
            if(Session["Cart"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.MaPhuongThuc = new SelectList(db.PHUONGTHUCTHANHTOANs.ToList().OrderBy(n => n.MaPhuongThuc), "MaPhuongThuc", "TenPhuongThuc");
            // Lấy giỏ hàng tử Session
            List<Cart> lstCart = Laygiohang();
            ViewBag.Tongsoluong = TongSoLuong();
            ViewBag.Tongtien = TongTien();
            return View(lstCart);
        }
        public ActionResult Order(FormCollection collection, DONDATHANG ddh)
        {
            ViewBag.MaPhuongThuc = new SelectList(db.PHUONGTHUCTHANHTOANs.ToList().OrderBy(n => n.MaPhuongThuc), "MaPhuongThuc", "TenPhuongThuc");
            //Them don hang
            //DONDATHANG ddh = new DONDATHANG();
            KHACHHANG kh = (KHACHHANG)Session["users"];
            List<Cart> gh = Laygiohang();
            ddh.MaKH = kh.MaKH;
            ddh.Ngaydat = DateTime.Now;
            var ngaygiao = String.Format("{0:MM/dd/yyyy}", collection["Ngaygiao"]);
            ddh.Ngaygiao = DateTime.Parse(ngaygiao);   
            ddh.Tinhtranggiaohang = false;
            ddh.Dathanhtoan = false;
            ddh.Trangthai = true;
            db.DONDATHANGs.Add(ddh);


            db.SaveChanges();
            //Them chi tiet don hang
            foreach (var item in gh)
            {
                CHITIETDONTHANG ctdh = new CHITIETDONTHANG();
                ctdh.MaDonHang = ddh.MaDonHang;
                ctdh.MaSP = item.iMaSP;
                ctdh.Soluong = item.iSoluong;
                ctdh.Dongia = (decimal)item.dDongia;
                db.CHITIETDONTHANGs.Add(ctdh);
            }
            db.SaveChanges();
            Session["Cart"] = null;
            return RedirectToAction("Xacnhandonhang", "Cart");
        }
        public ActionResult Xacnhandonhang()
        {
            return View();
        }
        
    }

}