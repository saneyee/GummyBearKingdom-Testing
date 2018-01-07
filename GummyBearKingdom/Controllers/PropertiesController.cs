using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GummyBearKingdom.Models;

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

        public IActionResult Details(int id)
        {
            var thisProperty = db.Properties.FirstOrDefault(Properties => Properties.PropertyId == id);
            return View(thisProperty);
        }


    }

}
