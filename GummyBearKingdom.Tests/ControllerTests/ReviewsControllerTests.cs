using System;
using System.Collections.Generic;
using System.Linq;
using GummyBearKingdom.Controllers;
using GummyBearKingdom.Models;
using GummyBearKingdom.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;


namespace GummyBearKingdom.Tests.ControllerTests
{
    [TestClass]
    public class ReviewsControllerTests
    {
        Mock<IReviewRepository> mock = new Mock<IReviewRepository>();

        private void DbSetup()
        {
            mock.Setup(m => m.Reviews).Returns(new Review[]
            {
                new Review {ReviewId = 1, Author= "Soma", Content = "Good", Rating = 2},
                new Review {ReviewId = 2, Author= "Berry", Content = "Bad", Rating = 5},
                new Review {ReviewId = 3, Author= "Chainy", Content = "Costly", Rating = 3},
            }.AsQueryable());
        }





    }
}
