using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class ShoppingCartController : Controller
    {
        ShoppingEntities2 storeDB = new ShoppingEntities2();

        public ActionResult Index()
        {
            var cart = ShoppingList.GetCart(this.HttpContext);


            var viewModel = new ShoppingCartViewModel
            {
                CartItems = cart.GetCartItems(),
                CartTotal = cart.GetTotal()
            };

            return View(viewModel);
        }

        public ActionResult AddToCart(int id)
        {
            var addedItem = storeDB.Things.Single(item => item.ThingId == id);

            var cart = ShoppingList.GetCart(this.HttpContext);
            cart.AddToCart(addedItem);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult RemoveFromCart(int id)
        {

            var cart = ShoppingList.GetCart(this.HttpContext);

            string itemName = storeDB.Carts.Single(item => item.RecordId == id).Thing.Title;

            int itemCount = cart.RemoveFromCart(id);

            var results = new ShoppingCartRemoveViewModel
            {
                CartTotal = cart.GetTotal(),
                CartCount = cart.GetCount(),
                ItemCount = itemCount,
                DeleteId = id
            };
            return Json(results);
        }

        public ActionResult CartSummary()
        {
            var cart = ShoppingList.GetCart(this.HttpContext);
            ViewData["CartCount"] = cart.GetCount();
            return PartialView("CartSummary");
        }
    }
}