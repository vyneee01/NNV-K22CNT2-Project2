using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThuVienSach_NguyenNgocVy.Bussiness;
using ThuVienSach_NguyenNgocVy.Models;
using ThuVienSach_NguyenNgocVy.ModelsViews;

namespace ThuVienSach_NguyenNgocVy.Controllers
{
    public class CartController : Controller
    {
        private const string CartSessionKey = "ShoppingCart";
        ThuVienSach_K22CNT2_NguyenNgocVyEntities db = new ThuVienSach_K22CNT2_NguyenNgocVyEntities();

        // Lấy giỏ hàng từ Session hoặc tạo mới nếu chưa có
        private ShoppingCart GetCart()
        {
            var cart = Session[CartSessionKey] as ShoppingCart;
            if (cart == null)
            {
                cart = new ShoppingCart();
                Session[CartSessionKey] = cart;
            }
            return cart;
        }
        // Thêm sản phẩm vào giỏ hàng
        public ActionResult AddToCart(int ID, string name, string image, int qty, float price )
        {

            var cart = GetCart();
            var item = new CartItem
            {
                ID = ID,
                TenSach = name,
                HinhAnh = image,
                SoLuongMua = qty,
                Gia = price,
                ThanhTien = price * qty,
            };
            cart.AddToCart(item);
            return RedirectToAction("Index");

        }
        public ActionResult UpdateToCart(int ID, int qty)
        {

            var cart = GetCart();
            cart.UpdateToCart(ID, qty);
            return RedirectToAction("Index");

        }

        // GET: Cart - Hiển thị các sản phâ
        public ActionResult Index()
        {
            var cart = GetCart();
            return View(cart.Items);
        }
        // Thông tin thanh toán
        public ActionResult ThongTinThanhToan()
        {
            var cart = GetCart();
            return View(cart);
        }
        public ActionResult ThanhToan(FormCollection form)
        {

            return Redirect("/");
        }
    }
}