using System;
using System.Data.Entity;

namespace WebApplication1.Models.DataAccess
{
    public class Init : DropCreateDatabaseIfModelChanges<CodeContext>
    {
        protected override void Seed(CodeContext context)
        {
            base.Seed(context);

            //var office806 = new Location { LocationName = "Office806" };
            /*context.Products.Add(new Product
            {                
                Name = "Nout1",
                Description = "sdfsdf"
            });
            context.Products.Add(new Product
            {
                Name = "Nout2",
                Description = "sdfs2332df"
            });*/

            context.SaveChanges();
        }
    }
}