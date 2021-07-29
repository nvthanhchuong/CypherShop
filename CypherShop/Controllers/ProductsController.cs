using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CypherShop.Models;
using PagedList;
using PagedList.Mvc;
namespace CypherShop.Controllers
{
    public class ProductsController : Controller
    {
        CypherShopEntities db = new CypherShopEntities();
        // GET: Products
        public ActionResult Index(int? page)
        {
            if (page == null) page = 1;
            var SANPHAM = (from l in db.SANPHAMs select l).OrderBy(x => x.MaSP);

            int pageSize = 15;

            int pageNumber = (page ?? 1);
            return View(SANPHAM.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Discount()
        {
            int d = 15;
            var lstSanPham = db.SANPHAMs.Where(n => n.Giamgia > d).ToList();
            ProductDetail objProductDetail = new ProductDetail();
            objProductDetail.ListSanPham = lstSanPham;
            return View(objProductDetail);
        }
        public ActionResult TheLoai()
        {
            var lstTheLoai = db.THELOAIs.ToList();
            ProductDetail pr = new ProductDetail();
            pr.ListTheLoai = lstTheLoai;
            return PartialView(pr);
        }
        public ActionResult SPTL(int sp)
        {
            var lstSanPham = db.SANPHAMs.Where(n => n.MaTL == sp).ToList();
            ProductDetail pra = new ProductDetail();
            pra.ListSanPham = lstSanPham;
            return PartialView(pra);
        }
    }
}