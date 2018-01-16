using System;
using System.Collections.Generic;
using System.Linq;
using GummyBearKingdom.Controllers;
using GummyBearKingdom.Models;
using GummyBearKingdom.Models.Repositories;
using GummyBearKingdom.Tests.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;


namespace GummyBearKingdom.Tests.ControllerTests
{
    [TestClass]
    public class ReviewsControllerTests : IDisposable
    {
        Mock<IReviewRepository> mock = new Mock<IReviewRepository>();

        EFReviewRepository db = new EFReviewRepository(new TestDbContext());

        private void DbSetup()
        {
            mock.Setup(m => m.Reviews).Returns(new Review[]
            {
                new Review {ReviewId = 1, Author= "Soma", Content = "Good", Rating = 2},
                new Review {ReviewId = 2, Author= "Berry", Content = "Bad", Rating = 5},
                new Review {ReviewId = 3, Author= "Chainy", Content = "Costly", Rating = 3},
            }.AsQueryable());
        }

        [TestMethod]
        public void Mock_GetViewResultIndex_ActionResult() // Confirms route returns view
        {
            //Arrange
            DbSetup();
            ReviewsController controller = new ReviewsController(mock.Object);

            //Act
            var result = controller.Index();

            //Assert
            Assert.IsInstanceOfType(result, typeof(ActionResult));
        }

        [TestMethod]
        public void Mock_IndexContainsModelData_List() // Confirms model as list of reviews
        {
            // Arrange
            DbSetup();
            ViewResult indexView = new ReviewsController(mock.Object).Index() as ViewResult;

            // Act
            var result = indexView.ViewData.Model;

            // Assert
            Assert.IsInstanceOfType(result, typeof(List<Review>));
        }

        [TestMethod]
        public void Mock_IndexModelContainsReviews_Collection() // Confirms presence of known entry
        {
            // Arrange
            DbSetup();
            ReviewsController controller = new ReviewsController(mock.Object);
            Review testReview = new Review();
            testReview.Author = "Soma";
            testReview.Content = "Good";
            testReview.Rating = 2;
            testReview.ReviewId = 1;

            // Act
            ViewResult indexView = controller.Index() as ViewResult;
            List<Review> collection = indexView.ViewData.Model as List<Review>;

            // Assert
            CollectionAssert.Contains(collection, testReview);
        }

        [TestMethod]
        public void Mock_PostViewResultCreate_ViewResult()
        {
            // Arrange
            Review testReview = new Review
            {
                ReviewId = 4,
                Author = "Darwin"
            };

            DbSetup();
            ReviewsController controller = new ReviewsController(mock.Object);

            // Act
            var resultView = controller.Create(testReview) as ViewResult;


            // Assert
            Assert.IsInstanceOfType(resultView, typeof(ViewResult));

        }

        [TestMethod]
        public void Mock_GetDetails_ReturnsView()
        {
            // Arrange
            Review testReview = new Review
            {
                ReviewId = 4,
                Author = "Darwin"
            };

            DbSetup();
            ReviewsController controller = new ReviewsController(mock.Object);

            // Act
            var resultView = controller.Details(testReview.ReviewId) as ViewResult;
            var model = resultView.ViewData.Model as Review;

            // Assert
            Assert.IsInstanceOfType(resultView, typeof(ViewResult));
            Assert.IsInstanceOfType(model, typeof(Review));
        }

        [TestMethod]
        public void DB_CreatesNewReviews_Collection()
        {
            // Arrange
            ReviewsController controller = new ReviewsController(db);
            Review testReview = new Review();
            testReview.Author = "TestDb Review";
            testReview.Content = "Good";
            testReview.Rating = 4;


            // Act
            controller.Create(testReview);
            var collection = (controller.Index() as ViewResult).ViewData.Model as List<Review>;

            // Assert
            CollectionAssert.Contains(collection, testReview);
        }

        public void Dispose()
        {
            db.DeleteAll();
        }

    }
}
