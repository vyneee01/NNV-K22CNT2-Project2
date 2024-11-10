using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThuVienSach_NguyenNgocVy.ModelsViews
{
    public class CartItem
    {
        public int ID { get; set; }
        public string TenSach { get; set; }
        public string HinhAnh { get; set; }
        public int SoLuongMua { get; set; }
        public float Gia { get; set; }
        public float ThanhTien { get; set; }
    }
}