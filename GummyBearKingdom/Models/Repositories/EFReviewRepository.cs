//using System;
//using System.Linq;
//using Microsoft.EntityFrameworkCore;
//using System.Collections.Generic;
//using System.Threading.Tasks;

//namespace GummyBearKingdom.Models.Repositories
//{
//    public class EFReviewRepository : IReviewRepository
//    {
//        GummyBearKingdomDbContext db = new GummyBearKingdomDbContext();

//        public IQueryable<Review> Reviews
//        { get { return db.Reviews; } }

//        public Review Save(Review review)
//        {
//            db.Reviews.Add(review);
//            db.SaveChanges();
//            return review;
//        }

//        public Review Edit(Review review)
//        {
//            db.Entry(review).State = EntityState.Modified;
//            db.SaveChanges();
//            return review;
//        }

//        public void Remove(Review review)
//        {
//            db.Reviews.Remove(review);
//            db.SaveChanges();
//        }

//    }
//}
