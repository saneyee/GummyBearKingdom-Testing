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

        //[TestMethod]
        //public void GetDescription_ReturnsReviewDescription_String()
        //{
        //    //Arrange
        //    var review = new Review();


        //    //Act
        //    var result = review.Description = "Used in summer";

        //    //Assert
        //    Assert.AreEqual("Used in summer", result);
        //}
    }
}