using sample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using sample.ViewModels;

namespace sample.Controllers
{
    public class MenuItemController : Controller
    {
        TruYumContext t = new TruYumContext();
        // GET: MenuItems
        public ActionResult Index(bool isAdmin)
        {try
            {
                if (isAdmin == true)
                {
                    ViewBag.isAdmin = true;
                    var itemlist = t.MenuItems.Include(m => m.Category).ToList();
                    return View("MenuItem", itemlist);
                }
                else
                {
                    ViewBag.isAdmin = false;
                    var itemlist = (from c in t.MenuItems.Include(m => m.Category) where DateTime.Now > c.DateOfLaunch && c.Active == true select c).ToList();
                    return View("MenuItem", itemlist);
                }
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                return View("Error");
            }
        }
        
        public ActionResult Create()
        {
            
                var Categories = t.Categories.ToList();
                CreateViewModel v = new CreateViewModel { Categories = Categories };
                return View(v);
            
        
         }
        [HttpPost]
        public ActionResult Create(CreateViewModel item)
        {
            if (!ModelState.IsValid)
            {
                var Categories = t.Categories.ToList();
                CreateViewModel v = new CreateViewModel { Categories = Categories,MenuItem=item.MenuItem };
                return View("Create", v);
            }
            else
            {
                t.MenuItems.Add(item.MenuItem);
                t.SaveChanges();
                return RedirectToAction("Index", "MenuItem", new { isAdmin = true });
            }
         }
        public ActionResult Edit(int id)
        {
            try
            {
                MenuItem m = t.MenuItems.Find(id);
                var Categories = t.Categories.ToList();
                CreateViewModel v = new CreateViewModel { Categories = Categories, MenuItem = m };
                return View(v);
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                return View("Error");
            }
        }
        [HttpPost]
        public ActionResult Edit(CreateViewModel item)
        {
            try
            {
                MenuItem m = t.MenuItems.Find(item.MenuItem.Id);
                m.Name = item.MenuItem.Name;
                m.Active = item.MenuItem.Active;
                m.FreeDelivery = item.MenuItem.FreeDelivery;
                m.DateOfLaunch = item.MenuItem.DateOfLaunch;
                m.Price = item.MenuItem.Price;
                m.CategoryId = item.MenuItem.CategoryId;
                t.SaveChanges();
                return RedirectToAction("Index", "MenuItem", new { isAdmin = true });
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                return View("Error");
            }
        }
    }
}