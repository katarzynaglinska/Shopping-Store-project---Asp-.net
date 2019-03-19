using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;
using System.Collections.Generic;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        ShoppingEntities2 StoreDB = new ShoppingEntities2();

        private List<Thing> SomeItems(int count)
        {
            return StoreDB.Things.OrderByDescending(i => i.TransactionDetails.Count()).Take(count).ToList();
        }

        public ActionResult Index()
        {
            var items = SomeItems(10);
            return View(items);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}