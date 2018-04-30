using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebApplication1.Models.Core;
using WebApplication1.Models.DataAccess;
using WebApplication1.Models.Core.Shop;
using System.Data.Entity;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {        
        ParserWorker<string[]> parser;
        string res;
        public CodeContext ctx = new CodeContext("dbContext1");
        public async Task<ActionResult> Index()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<CodeContext>());
            parser = new ParserWorker<string[]>( new ShopParser(), new ShopSettings(1, 1));
            parser.OnCompleted += Parser_OnCompleted;
            parser.OnNewData += Parser_OnNewData;                        
            ViewBag.Message = res;
            ViewBag.Title = "Rozetka Parser";
            List<Product> attendees = new List<Product>();
                
                    string stri = await parser.Worker(ctx);
                    attendees = ctx.Products.ToList();
                    ViewBag.Count = attendees.Count();
                    ViewBag.Product1 = attendees[0];                
            
            return View(attendees);
        }

        public ActionResult Good (Product product)
        {
            ViewBag.Name = product.Name;
            ViewBag.Description = product.Description;
            ViewBag.Picture = product.Picture;
            var pri = ctx.Prices.OrderBy(p => p.DateAdded).Where(p => p.ProductID == product.ProductID).ToList();
            return View(pri);
        }

        private void Parser_OnNewData(object arg1, string[] arg2)
        {
            foreach (string element in arg2)
            {
                res += element;
            }           
        }

        private void Parser_OnCompleted(object obj)
        {
            ViewBag.End = "END!";
        }
    }
}