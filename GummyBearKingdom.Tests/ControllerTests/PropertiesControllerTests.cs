﻿using System;
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
    public class PropertiesControllerTests
    {
        Mock<IPropertyRepository> mock = new Mock<IPropertyRepository>();

        private void DbSetup()
        {
            mock.Setup(m => m.Properties).Returns(new Property[]
            {
                new Property {PropertyId = 1, Name= "Sofa", Cost = 200, Description = "Comfortable", ReviewId = 1},
                new Property {PropertyId = 2, Name= "Bed", Cost = 300, Description = "King", ReviewId = 2},
                new Property {PropertyId = 3, Name= "Chair", Cost = 400, Description = "Folding", ReviewId = 1},
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
        
    }
}
