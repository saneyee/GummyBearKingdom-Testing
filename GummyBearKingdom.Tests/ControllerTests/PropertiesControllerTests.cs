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
    public class PropertiesControllerTests : IDisposable
    {
        Mock<IPropertyRepository> mock = new Mock<IPropertyRepository>();

        EFPropertyRepository db = new EFPropertyRepository(new TestDbContext());


        private void DbSetup()
        {
            mock.Setup(m => m.Properties).Returns(new Property[]
            {
                new Property {PropertyId = 1, Name= "Sofa", Cost = 200, Description = "Comfortable"},
                new Property {PropertyId = 2, Name= "Bed", Cost = 300, Description = "King"},
                new Property {PropertyId = 3, Name= "Chair", Cost = 400, Description = "Folding"},
            }.AsQueryable());
        }

        [TestMethod]
        public void Mock_GetViewResultIndex_ActionResult() // Confirms route returns view
        {
            //Arrange
            DbSetup();
            PropertiesController controller = new PropertiesController(mock.Object);

            //Act
            var result = controller.Index();

            //Assert
            Assert.IsInstanceOfType(result, typeof(ActionResult));
        }

        [TestMethod]
        public void Mock_IndexContainsModelData_List() // Confirms model as list of properties
        {
            // Arrange
            DbSetup();
            ViewResult indexView = new PropertiesController(mock.Object).Index() as ViewResult;

            // Act
            var result = indexView.ViewData.Model;

            // Assert
            Assert.IsInstanceOfType(result, typeof(List<Property>));
        }

        [TestMethod]
        public void Mock_IndexModelContainsProperties_Collection() // Confirms presence of known entry
        {
            // Arrange
            DbSetup();
            PropertiesController controller = new PropertiesController(mock.Object);
            Property testProperty = new Property();
            testProperty.Name = "Sofa";
            testProperty.Cost = 200;
            testProperty.Description = "Comfortable";
            testProperty.PropertyId = 1;

            // Act
            ViewResult indexView = controller.Index() as ViewResult;
            List<Property> collection = indexView.ViewData.Model as List<Property>;

            // Assert
            CollectionAssert.Contains(collection, testProperty);
        }

        [TestMethod]
        public void Mock_PostViewResultCreate_ViewResult()
        {
            // Arrange
            Property testProperty = new Property
            {
                PropertyId = 4,
                Name = "Drawer"
            };

            DbSetup();
            PropertiesController controller = new PropertiesController(mock.Object);

            // Act
            var resultView = controller.Create(testProperty) as ViewResult;


            // Assert
            Assert.IsInstanceOfType(resultView, typeof(ViewResult));

        }

        [TestMethod]
        public void Mock_GetDetails_ReturnsView()
        {
            // Arrange
            Property testProperty = new Property
            {
                PropertyId = 4,
                Name = "Drawer"
            };

            DbSetup();
            PropertiesController controller = new PropertiesController(mock.Object);

            // Act
            var resultView = controller.Details(testProperty.PropertyId) as ViewResult;
            var model = resultView.ViewData.Model as Property;

            // Assert
            Assert.IsInstanceOfType(resultView, typeof(ViewResult));
            Assert.IsInstanceOfType(model, typeof(Property));
        }

        [TestMethod]
        public void DB_CreatesNewProperties_Collection()
        {
            // Arrange
            PropertiesController controller = new PropertiesController(db);
            Property testProperty = new Property();
            testProperty.Name = "TestDb Property";
            testProperty.Cost = 400;
            testProperty.Description = "Big";

            // Act
            controller.Create(testProperty);
            var collection = (controller.Index() as ViewResult).ViewData.Model as List<Property>;

            // Assert
            CollectionAssert.Contains(collection, testProperty);
        }

        public void Dispose()
        {
            db.DeleteAll();
        }
        
    }
}
