using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace CypherShop.Models
{
    public class Cart
    {
        //public SANPHAM SanPham { get; set; }
        //public int Quantity { get; set; }
        CypherShopEntities db = new CypherShopEntities();
        public int iMaSP { get; set; }
        public string sTenSP { get; set; }
        public string sAnhbia { get; set; }
        public double dDongia { get; set; }
        public int iSoluong { get; set; }
        public double dThanhtien
        {
            get { return iSoluong * dDongia; }
        }
        //Khởi tạo giỏ hàng theo mã sách được truyền vào (Mặc định là 1)
        public Cart(int MaSP)
        {
            iMaSP = MaSP;
            SANPHAM sp = db.SANPHAMs.Single(n => n.MaSP == iMaSP);
            sTenSP = sp.TenSP;
            sAnhbia = sp.Anhbia;
            dDongia = double.Parse(sp.Giaban.ToString());
            iSoluong = 1;

        }
    }
}