using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {
        ShoppingEntities2 storeDB = new ShoppingEntities2();

        public ActionResult AddressAndPayment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddressAndPayment(FormCollection values)
        {
            var order = new Transaction();
            TryUpdateModel(order);

            try
            {
                    order.Username = User.Identity.Name;
                    order.OrderDate = DateTime.Now;

                    storeDB.Transactions.Add(order);
                    storeDB.SaveChanges();

                    var cart = ShoppingList.GetCart(this.HttpContext);
                    cart.CreateOrder(order);

                    return RedirectToAction("Complete", new { id = order.TransactionId });
            }
            catch
            {
                return View(order);
            }
        }

        public ActionResult Complete(int id)
        {

            bool isValid = storeDB.Transactions.Any(
                o => o.TransactionId == id &&
                o.Username == User.Identity.Name);

            if (isValid)
            {
                return View(id);
            }
            else
            {
                return View("Error");
            }
        }
    }
}