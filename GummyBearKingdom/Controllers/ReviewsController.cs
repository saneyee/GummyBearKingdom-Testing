﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GummyBearKingdom.Models;
using GummyBearKingdom.Models.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GummyBearKingdom.Controllers
{
    public class ReviewsController : Controller
    {
        private IReviewRepository reviewRepo;  // New!

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
            return View(reviewRepo.Reviews.ToList());
        }

        public IActionResult Details(int id)
        {
            Review thisReview = reviewRepo.Reviews.FirstOrDefault(Reviews => Reviews.ReviewId == id);
            return View(thisReview);
        }

        public IActionResult Create()
        {
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
            Review thisReview = reviewRepo.Reviews.FirstOrDefault(properties => properties.ReviewId == id);

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
            Review thisReview = reviewRepo.Reviews.FirstOrDefault(properties => properties.ReviewId == id);
            return View(thisReview);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            Review thisReview = reviewRepo.Reviews.FirstOrDefault(properties => properties.ReviewId == id);
            reviewRepo.Remove(thisReview);
            return RedirectToAction("Index");
        }

    }
}
