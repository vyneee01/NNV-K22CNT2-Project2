//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ThuVienSach_NguyenNgocVy.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class GIAO_DICH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GIAO_DICH()
        {
            this.CHI_TIET_GIAO_DICH = new HashSet<CHI_TIET_GIAO_DICH>();
        }
    
        public int MaGD { get; set; }
        public Nullable<int> MaKH { get; set; }
        public Nullable<int> MaSach { get; set; }
        public System.DateTime NgayMuon { get; set; }
        public Nullable<System.DateTime> NgayTraDuKien { get; set; }
        public Nullable<System.DateTime> NgayTraThucTe { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHI_TIET_GIAO_DICH> CHI_TIET_GIAO_DICH { get; set; }
        public virtual KHACH_HANG KHACH_HANG { get; set; }
        public virtual SACH SACH { get; set; }
    }
}
