using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication1.Models;

namespace WebApplication1.Tests.Models
{
    [TestClass]
    public class ProductTest
    {
        [TestMethod]
        public void CanChangeProductName()
        {
            // Arrange
            var p = new Product { Name = "Test", Description = "100M" };
            // Act
            p.Name = "New Name";
            //Assert
            Assert.AreEqual("New Name", p.Name);
        }

        [TestMethod]
        public void CanChangeProductDescription()
        {
            // Arrange
            var p = new Product { Name = "Test", Description = "100M" };
            // Act
            p.Description = "New Description";
            //Assert
            Assert.AreEqual("New Description", p.Description);
        }
    }
}
