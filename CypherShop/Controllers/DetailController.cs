using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CypherShop.Models;

namespace CypherShop.Controllers
{
    public class DetailController : Controller
    {
        CypherShopEntities db = new CypherShopEntities();
        // GET: Detail
        public ActionResult Index(int Id, int nsx)
        {
            // lấy thông tin sản phẩm theo id
            var objSanPham = db.SANPHAMs.Where(n => n.MaSP == Id).FirstOrDefault();
            //Lây danh sách sản phẩm liên quan trong MaTL trong objsanpham
            var lstSanPham = db.SANPHAMs.Where(n => n.MaTL == objSanPham.MaTL).ToList();
            // lấy thông tin sản phẩm theo id nsx
            var objNhaSanXuat = db.NHASANXUATs.Where(n => n.MaNSX == nsx).FirstOrDefault();

            ProductDetail objProductDetail = new ProductDetail();
            objProductDetail.objSanPham = objSanPham;
            objProductDetail.ListSanPham = lstSanPham;
            objProductDetail.objNhaSanXuat = objNhaSanXuat;


            return View(objProductDetail);
        }
    }
}