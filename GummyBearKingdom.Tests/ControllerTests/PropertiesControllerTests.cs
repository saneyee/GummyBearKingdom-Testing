using System;




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
        
    }
}
