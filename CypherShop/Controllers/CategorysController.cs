using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CypherShop.Models;

namespace CypherShop.Controllers
{
    public class CategorysController : Controller
    {
        CypherShopEntities db = new CypherShopEntities();
        // GET: Categorys
        public ActionResult Categorys()
        {
            var lstNhaSanXuat = db.NHASANXUATs.ToList();
            var lstSanPham = db.SANPHAMs.ToList();
            ProductDetail objpro = new ProductDetail();
            objpro.ListNhaSanXuat = lstNhaSanXuat;
            objpro.ListSanPham = lstSanPham;
            return PartialView(objpro); 
        }
        public ActionResult NhaSanXuat( int Idsp, int mnsx )
        { 
            var lstSanPham = db.SANPHAMs.Where( n => n.MaNSX == Idsp).ToList();
            var objNhaSanXuat = db.NHASANXUATs.Where(n => n.MaNSX == mnsx).FirstOrDefault();
            ProductDetail productDetail = new ProductDetail();
            productDetail.objNhaSanXuat = objNhaSanXuat;
            productDetail.ListSanPham = lstSanPham;
            return View(productDetail);
        }
    }
}