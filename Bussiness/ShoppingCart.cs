using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ThuVienSach_NguyenNgocVy.ModelsViews;

namespace ThuVienSach_NguyenNgocVy.Bussiness
{
    public class ShoppingCart
    {
        public List<CartItem> Items { get; set; }
        public ShoppingCart()
        {
            Items = new List<CartItem>();
        }


        public void AddToCart(CartItem item)
        {
            var existingItem = Items.FirstOrDefault(i => i.ID == item.ID);
            if (existingItem != null)
            {
                existingItem.SoLuongMua += item.SoLuongMua;
            }
            else
            {
                Items.Add(item);
            }
        }
        // xóa sản phẩm trong giỏ hàng
        public void UpdateToCart(int id, int qty)
        {
            var existingItem = Items.FirstOrDefault(i => i.ID == id);
            if (existingItem != null)
            {
                existingItem.SoLuongMua = qty;
            }
        }
        public void RemoveFromCart(int productId)
        {
            var itemToremove = Items.FirstOrDefault(i => i.ID == productId);
            if (itemToremove != null)
            {
                Items.Remove(itemToremove);
            }
        }

        // Tính tổng tiền của giỏ hàng
        public float GetTotal()
        {
            return Items.Sum(i => i.Gia * i.SoLuongMua);
        }
    }
}