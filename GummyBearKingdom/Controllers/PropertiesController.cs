//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using GummyBearKingdom.Models;
//using Microsoft.EntityFrameworkCore;
//using GummyBearKingdom.Models.Repositories;

//namespace GummyBearKingdom.Controllers
//{
//    public class PropertiesController : Controller
//    {
//        private IPropertyRepository propertyRepo; 
//        // New!
//        private GummyBearKingdomDbContext db = new GummyBearKingdomDbContext();

//        public PropertiesController(IPropertyRepository repo = null)
//        {
//            if (repo == null)
//            {
//                this.propertyRepo = new EFPropertyRepository();
//            }
//            else
//            {
//                this.propertyRepo = repo;
//            }
//        }

//        public IActionResult Index()
//        {
//            return View(propertyRepo.Properties.Include(properties => properties.Review).ToList());
//        }

//        public IActionResult Details(int id)
//        {
//            Property thisProperty = propertyRepo.Properties.FirstOrDefault(properties => properties.PropertyId == id);
//            return View(thisProperty);
//        }

//        public IActionResult Create()
//        {
//            ViewBag.ReviewId = new SelectList(db.Reviews, "ReviewId", "Content");
//            return View();
//        }

//        [HttpPost]
//        public IActionResult Create(Property property)
//        {
//            propertyRepo.Save(property);
//            return RedirectToAction("Index");
//        }

//        public IActionResult Edit(int id)
//        {
//            Property thisProperty = propertyRepo.Properties.FirstOrDefault(properties => properties.PropertyId == id);
//            ViewBag.ReviewId = new SelectList(db.Reviews, "ReviewId", "Content");
//            return View(thisProperty);
//        }

//        [HttpPost]
//        public IActionResult Edit(Property property)
//        {
//            propertyRepo.Edit(property);
//            return RedirectToAction("Index");
//        }

//        public ActionResult Delete(int id)
//        {
//            Property thisProperty = propertyRepo.Properties.FirstOrDefault(properties => properties.PropertyId == id);
//            return View(thisProperty);
//        }

//        [HttpPost, ActionName("Delete")]
//        public IActionResult DeleteConfirmed(int id)
//        {
//            Property thisProperty = propertyRepo.Properties.FirstOrDefault(properties => properties.PropertyId == id);
//            propertyRepo.Remove(thisProperty);
//            return RedirectToAction("Index");
//        }





//    }

//}
