// Controllers/ProductController.cs
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Web.Mvc;
using YourNamespace.Models;

namespace YourNamespace.Controllers
{
    public class ProductController : Controller
    {
        // Sample product data
        private static List<Product> Products = new List<Product>
        {
            new Product { Id = 1, Name = "Product 1", Price = 10.00M },
            new Product { Id = 2, Name = "Product 2", Price = 20.00M },
            new Product { Id = 3, Name = "Product 3", Price = 30.00M },
        };

        public ActionResult Index()
        {
            return View(Products); // Pass the product list to the view
        }

        public ActionResult AddToCart(int productId)
        {
            // Retrieve cart from cookies
            var cartCookie = Request.Cookies["Cart"];
            List<CartItem> cart = new List<CartItem>();

            if (cartCookie != null)
            {
                // Deserialize the cookie to retrieve existing cart items
                cart = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CartItem>>(cartCookie.Value);
            }

            // Check if the product is already in the cart
            var existingItem = cart.Find(item => item.ProductId == productId);
            if (existingItem != null)
            {
                existingItem.Quantity++; // Increment quantity if already in cart
            }
            else
            {
                cart.Add(new CartItem { ProductId = productId, Quantity = 1 }); // Add new item
            }

            // Serialize the cart and store it in a cookie
            var cartJson = Newtonsoft.Json.JsonConvert.SerializeObject(cart);
            Response.Cookies.Add(new HttpCookie("Cart", cartJson) { Expires = DateTime.Now.AddDays(30) }); // Expires in 30 days

            return RedirectToAction("Index");
        }

        public ActionResult Cart()
        {
            // Retrieve cart from cookies
            var cartCookie = Request.Cookies["Cart"];
            List<CartItem> cart = new List<CartItem>();

            if (cartCookie != null)
            {
                // Deserialize the cookie to retrieve existing cart items
                cart = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CartItem>>(cartCookie.Value);
            }

            return View(cart); // Pass the cart to the view
        }
    }
}
