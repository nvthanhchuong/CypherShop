using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CypherShop.Models
{
    public class Order
    {
        public List<PHUONGTHUCTHANHTOAN> ListPTTH { get; set; }
        public List<SANPHAM> ListSanPham { get; set; }
    }
}