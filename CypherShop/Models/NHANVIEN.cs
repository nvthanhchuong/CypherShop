//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CypherShop.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class NHANVIEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NHANVIEN()
        {
            this.DONDATHANGs = new HashSet<DONDATHANG>();
        }
    
        public string MaNV { get; set; }
        public string HoTen { get; set; }
        public string Taikhoan { get; set; }
        public string Matkhau { get; set; }
        public int IdChucVu { get; set; }
        public string Anh { get; set; }
        public string Email { get; set; }
        public string DiachiNV { get; set; }
        public string DienthoaiNV { get; set; }
        public Nullable<System.DateTime> Ngaysinh { get; set; }
        public string Nhaplaimatkhau { get; set; }
    
        public virtual CHUCVU CHUCVU { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DONDATHANG> DONDATHANGs { get; set; }
    }
}
