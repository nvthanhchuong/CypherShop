using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CypherShop.Models
{
    public class ChangePasswordModel
    {
        public string Taikhoan { get; set; }

        public string Matkhaucu { get; set; }

        public string Matkhaumoi { get; set; }

        public string Nhaplaimatkhau { get; set; }
    }
}