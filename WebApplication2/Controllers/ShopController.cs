using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class ShopController : Controller
    {

        ShoppingEntities2 storeDB = new ShoppingEntities2();
       

        public ActionResult Browse(string category)
        {
            var categoryModel = storeDB.Categories.Include("Things").Single(c => c.Name == category);
            return View(categoryModel);
        }

      
        public ActionResult CategoryMenu()
        {
            var categories = storeDB.Categories.ToList();
            return PartialView(categories);
        }

        public ActionResult ThingInfo(int id)
        {
            var Item = storeDB.Things.Find(id);
            return View(Item);
        }

    }
}