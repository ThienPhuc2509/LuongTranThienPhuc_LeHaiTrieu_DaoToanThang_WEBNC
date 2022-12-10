using DOAN_THWEB_NC.DesignPattern.CommandPattern;
using DOAN_THWEB_NC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace DOAN_THWEB_NC.Controllers
{
    public class ShoppingCartController : Controller
    {
        DB_Shop2Entities3 _db =new DB_Shop2Entities3();
        // GET: ShoppingCart
        public Cart GetCart()
        {
            Cart cart = Session["Cart"] as Cart;
            if (cart == null || Session["Cart"] == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
        public ActionResult AddCart(int id)
        {
            var pro = _db.Products.SingleOrDefault(s => s.IDProduct == id);
            if (pro != null)
            {
                GetCart().Add(pro);
            }
            return RedirectToAction("ShowCart", "ShoppingCart");
        }
        public ActionResult ShowCart()
        {
            if (Session["Cart"] == null)
                return RedirectToAction("ShowCart", "ShoppingCart");
            Cart cart=Session["Cart"]as Cart;
            return View(cart);
        }
        public ActionResult Update_Quantity_Cart(FormCollection form)
        {
            Cart cart = Session["Cart"] as Cart;
            int id_pro = int.Parse(form["ID_Product"]);
            int quantity = int.Parse(form["Quantity"]);
            cart.Update_Quantity_Shopping(id_pro, quantity);
            return RedirectToAction("ShowCart", "ShoppingCart");
        }
        public ActionResult RemoveCart(int id)
        {
            Cart cart = Session["Cart"] as Cart;
            cart.Remove_CartItem(id);
            return RedirectToAction("ShowCart", "ShoppingCart");
        }
        public PartialViewResult BagCart()
        {
            int _t_item = 0;
            Cart cart=Session["Cart"] as Cart;
            if (cart != null)
            {
                _t_item = cart.Total_Quantity();
            }
            ViewBag.infoCart = _t_item;
            return PartialView("BagCart");
        }
        public ActionResult Shopping_Success()
        {
            return View();
        }
        private readonly ICommand isCheckout;
        private readonly ICommand isNotCheckout;
        public ActionResult Checkout(FormCollection form,User user)
        {
            if (Session["IDUser"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                Cart cart = Session["Cart"] as Cart;
                
                foreach (var item in cart.Items)
                {
                    Order _order = new Order();
                    _order.NameUser = form["Name_User"];
                    _order.OrderDate = DateTime.Now;
                    _order.Addresss = form["Address_delivery"];
                    _order.SDT = int.Parse(form["SDT_Cus"]);
                    
                    _order.UnitPriceSale = item._shopping_product.UnitPrice;
                    _order.Quantity = item._shoppping_quantity;
                    _order.NameProduct=item._shopping_product.NameProduct;
                    _order.IDProduct = item._shopping_product.IDProduct;
                    _db.Orders.Add(_order);
                }
                
                _db.SaveChanges();
                cart.ClearCart();
                isCheckout.Execute();
                return RedirectToAction("Shopping_Success", "ShoppingCart");
            }   
        }
    }
}