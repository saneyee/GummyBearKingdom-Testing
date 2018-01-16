using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using GummyBearKingdom.Models;
using Microsoft.EntityFrameworkCore;
using GummyBearKingdom.Models.Repositories;

namespace GummyBearKingdom.Controllers
{
    public class PropertiesController : Controller
    {
        private IPropertyRepository propertyRepo;  // New!

        public PropertiesController(IPropertyRepository repo = null)
        {
            if (repo == null)
            {
                this.propertyRepo = new EFPropertyRepository();
            }
            else
            {
                this.propertyRepo = repo;
            }
        }

        public IActionResult Index()
        {
            return View(propertyRepo.Properties.ToList());
        }

        //public IActionResult Details(int id)
        //{
        //    var thisProperty = propertyRepo.Properties.FirstOrDefault(Properties => Properties.PropertyId == id);
        //    return View(thisProperty);
        //}

        //public IActionResult Create()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult Create(Property property)
        //{
        //    propertyRepo.Properties.Add(property);
        //    propertyRepo.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //public IActionResult Edit(int id)
        //{
        //    var thisProperty = propertyRepo.Properties.FirstOrDefault(properties => properties.PropertyId == id);

        //    return View(thisProperty);
        //}

        //[HttpPost]
        //public IActionResult Edit(Property property)
        //{
        //    propertyRepo.Entry(property).State = EntityState.Modified;
        //    propertyRepo.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //public ActionResult Delete(int id)
        //{
        //    var thisProperty = propertyRepo.Properties.FirstOrDefault(properties => properties.PropertyId == id);
        //    return View(thisProperty);
        //}

        //[HttpPost, ActionName("Delete")]
        //public IActionResult DeleteConfirmed(int id)
        //{
        //    var thisProperty = propertyRepo.Properties.FirstOrDefault(properties => properties.PropertyId == id);
        //    propertyRepo.Properties.Remove(thisProperty);
        //    propertyRepo.SaveChanges();
        //    return RedirectToAction("Index");
        //}





    }

}
