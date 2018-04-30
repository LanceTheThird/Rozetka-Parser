using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication1;
using WebApplication1.Controllers;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Models.DataAccess;

namespace WebApplication1.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            //ViewResult 
            Task<ActionResult>  result = controller.Index() as Task<ActionResult>;

            // Assert
            Assert.IsNotNull(result);
        }

    }
}
