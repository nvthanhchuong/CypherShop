using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CypherShop.Models
{
    public class ProductDetail
    {   
        public SANPHAM objSanPham { get; set; }
        public List<THELOAI> ListTheLoai { get; set; }
        public List<SANPHAM> ListSanPham { get; set; }
        public NHASANXUAT objNhaSanXuat { get; set; }
        public List<NHASANXUAT> ListNhaSanXuat { get; set; }
        public List<Slide> ListSlide { get; set; }
    }
}