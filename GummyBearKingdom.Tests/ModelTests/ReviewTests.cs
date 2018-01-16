using GummyBearKingdom.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GummyBearKingdom.Tests
{
    [TestClass]
    public class ReviewTests
    {
        [TestMethod]
        public void GetAuthor_ReturnsReviewAuthor_String()
        {
            //Arrange
            var review = new Review();


            //Act
            var result = review.Author = "Edd";

            //Assert
            Assert.AreEqual("Edd", result);
        }

        [TestMethod]
        public void GetContent_ReturnsReviewContent_String()
        {
            //Arrange
            var review = new Review();


            //Act
            var result = review.Content = "Very good";

            //Assert
            Assert.AreEqual("Very good", result);
        }

        [TestMethod]
        public void GetRating_ReturnsReviewRating_Int()
        {
            //Arrange
            var review = new Review();


            //Act
            var result = review.Rating = 3;

            //Assert
            Assert.AreEqual(3, result);
        }
    }
}