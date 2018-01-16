using GummyBearKingdom.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GummyBearKingdom.Tests
{
    [TestClass]
    public class PropertyTests
    {
        [TestMethod]
        public void GetName_ReturnsPropertyName_String()
        {
            //Arrange
            var property = new Property();


            //Act
            var result = property.Name = "Fan";

            //Assert
            Assert.AreEqual("Fan", result);
        }

        [TestMethod]
        public void GetCost_ReturnsPropertyCost_Int()
        {
            //Arrange
            var property = new Property();


            //Act
            var result = property.Cost = 200;

            //Assert
            Assert.AreEqual(200, result);
        }

        //[TestMethod]
        //public void GetSex_ReturnsPropertySex_String()
        //{
        //    //Arrange
        //    var property = new Property();


        //    //Act
        //    var result = property.Sex = "male";

        //    //Assert
        //    Assert.AreEqual("male", result);
        //}
    }
}
