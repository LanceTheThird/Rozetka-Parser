using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication1.Models.Core.Shop;
using WebApplication1.Models.Core;
using AngleSharp.Parser.Html;
using System.Threading.Tasks;

namespace WebApplication1.Tests.Models
{
    [TestClass]
    public class ShopParserTest
    {
        [TestMethod]
        public async Task CanParse()
        {
            // Arrange
            IParserSettings parserSettings  = new ShopSettings(1, 1);
            HtmlLoader loader = new HtmlLoader(parserSettings);
            ShopParser parser = new ShopParser();
            var domParser = new HtmlParser();
            var source = await loader.GetSourceByPageId(2);
            var document = await domParser.ParseAsync(source);

            // Act
            var result = parser.Parse(document);

            //Assert
            Assert.IsNotNull(parser.PricesList);

        }

    }
}
