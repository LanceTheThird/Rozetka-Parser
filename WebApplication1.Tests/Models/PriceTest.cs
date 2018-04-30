using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication1.Models;
using System;

namespace WebApplication1.Tests.Models
{
    [TestClass]
    public class PriceTest
    {
        [TestMethod]
        public void CanChangeProductPrice()
        {
            // Arrange
            var p = new Product { Name = "Test", Description = "100M" };
            var price = new Price { ProductPrice = "123", DateAdded = DateTime.Now, Product = p };
            // Act
            price.ProductPrice = "321";
            //Assert
            Assert.AreEqual("321", price.ProductPrice);
        }

        [TestMethod]
        public void CanChangePriceTime()
        {
            // Arrange
            DateTime now = DateTime.Now;
            DateTime littleMore = new DateTime(2008, 5, 1, 8, 30, 52); ;
            var p = new Product { Name = "Test", Description = "100M" };
            var price = new Price { ProductPrice = "123", DateAdded = now, Product = p };
            // Act
            price.DateAdded = littleMore;
            //Assert
            Assert.AreEqual(littleMore, price.DateAdded);
        }
    }
}
