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

        [TestMethod]
        public void GetDescription_ReturnsPropertyDescription_String()
        {
            //Arrange
            var property = new Property();


            //Act
            var result = property.Description = "Used in summer";

            //Assert
            Assert.AreEqual("Used in summer", result);
        }
    }
}
