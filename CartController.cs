using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sample.Models;
using System.Data.Entity;
using sample.ViewModels;

namespace sample.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        TruYumContext t = new TruYumContext();
        public ActionResult Index()
        {try
                {
                
                var list = (from c in t.Cart.Include(c=>c.MenuItem.Category) select c).ToList();
                return View("ViewCart", list); }
            catch(Exception e)
            { ViewBag.Error = e.Message;
                return View("Error");
            }
        }     
        public ActionResult AddToCart(int id)
        {
            try
            {
                Cart c = new Cart() { Id = 1, MenuItem_Id = id};
                t.Cart.Add(c);
                t.SaveChanges();
                return RedirectToAction("Index", "Cart");
            }
            catch(Exception e)
            {
                ViewBag.Error = e.Message;
                return View("Error");
            }
        }
        public ActionResult Delete(int id)
        {
            try
            {
                Cart c = t.Cart.SingleOrDefault(m => m.MenuItem_Id == id);
                t.Cart.Remove(c);
                t.SaveChanges();
                return RedirectToAction("Index", "Cart");
            }
            catch(Exception e)
            {
                ViewBag.Error = e.Message;
                return View("Error");
            }
        }
    }
}