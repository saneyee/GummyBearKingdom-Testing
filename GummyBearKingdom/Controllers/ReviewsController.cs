using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GummyBearKingdom.Models;
using GummyBearKingdom.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GummyBearKingdom.Controllers
{
    public class ReviewsController : Controller
    {
        private IReviewRepository reviewRepo; 
        private GummyBearKingdomDbContext db = new GummyBearKingdomDbContext();// New!

        public ReviewsController(IReviewRepository repo = null)
        {
            if (repo == null)
            {
                this.reviewRepo = new EFReviewRepository();
            }
            else
            {
                this.reviewRepo = repo;
            }
        }

        public IActionResult Index()
        {
            return View(reviewRepo.Reviews.Include(reviews => reviews.Property).ToList());
        }

        public IActionResult Details(int id)
        {
            Review thisReview = reviewRepo.Reviews.FirstOrDefault(reviews => reviews.ReviewId == id);
            return View(thisReview);
        }

        public IActionResult Create()
        {
            ViewBag.PropertyId = new SelectList(db.Properties, "PropertyId", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Review review)
        {
            reviewRepo.Save(review);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            Review thisReview = reviewRepo.Reviews.FirstOrDefault(reviews => reviews.ReviewId == id);
            ViewBag.PropertyId = new SelectList(db.Properties, "PropertyId", "Name");
            return View(thisReview);
        }

        [HttpPost]
        public IActionResult Edit(Review review)
        {
            reviewRepo.Edit(review);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            Review thisReview = reviewRepo.Reviews.FirstOrDefault(reviews => reviews.ReviewId == id);
            return View(thisReview);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            Review thisReview = reviewRepo.Reviews.FirstOrDefault(reviews => reviews.ReviewId == id);
            reviewRepo.Remove(thisReview);
            return RedirectToAction("Index");
        }

    }
}
