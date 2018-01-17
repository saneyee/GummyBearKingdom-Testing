using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GummyBearKingdom.Models;
using GummyBearKingdom.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GummyBearKingdom.Controllers
{
    public class HomeController : Controller
    {


        private GummyBearKingdomDbContext db = new GummyBearKingdomDbContext();

        public IActionResult Index()
        {
			List<Property> featuredProducts = db.Properties
												.Include(properties => properties.Reviews)
												.OrderByDescending(properties => properties
												.AverageRating())
												.Take(3)
                                                .ToList();
			return View(featuredProducts); ;
        }
        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

		
    }
}
