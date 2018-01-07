using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GummyBearKingdom.Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GummyBearKingdom.Controllers
{
    public class PropertiesController : Controller
    {
        private GummyBearKingdomDbContext db = new GummyBearKingdomDbContext();

        public IActionResult Index()
        {
            return View(db.Properties.ToList());
        }

        public IActionResult Details(int id)
        {
            var thisProperty = db.Properties.FirstOrDefault(Properties => Properties.PropertyId == id);
            return View(thisProperty);
        }

        public IActionResult Create()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult Create(Property property)
        {
            db.Properties.Add(property);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var thisProperty = db.Properties.FirstOrDefault(properties => properties.PropertyId == id);

            return View(thisProperty);
        }

        [HttpPost]
        public IActionResult Edit(Property property)
        {
            db.Entry(property).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var thisProperty = db.Properties.FirstOrDefault(properties => properties.PropertyId == id);
            return View(thisProperty);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisProperty = db.Properties.FirstOrDefault(properties => properties.PropertyId == id);
            db.Properties.Remove(thisProperty);
            db.SaveChanges();
            return RedirectToAction("Index");
        }





    }

}
