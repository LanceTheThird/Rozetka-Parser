using System.Collections.Generic;
using AngleSharp.Dom.Html;

namespace WebApplication1.Models.Core
{
    public interface IParser<T> where T : class
    {
        List<Product> ProductsList { get; set; }
        List<Price> PricesList { get; set; }

        T Parse(IHtmlDocument document);
    }
}
