using System;
using System.Collections.Generic;
using System.Linq;
using AngleSharp.Dom.Html;

namespace WebApplication1.Models.Core.Shop
{
    public class ShopParser : IParser<string[]>
    {
        private List<Product> productsList = new List<Product>();
        private List<Price> priceList = new List<Price>();

        public List<Product> ProductsList { get { return productsList; } set { productsList = value; } }
        public List<Price> PricesList { get { return priceList; } set { priceList = value; } }

        public string[] Parse(IHtmlDocument document)
        {
            var list = new List<string>();
                                    
            var nameItems = document.QuerySelectorAll("div").Where(item => item.ClassName != null && item.ClassName.Contains("g-i-tile-i-title clearfix"));
            var descriptionItems = document.QuerySelectorAll("div").Where(item => item.ClassName != null && item.ClassName.Contains("short-description"));
            var priceItems = document.QuerySelectorAll("div").Where(item => item.ClassName != null && item.ClassName.Contains("g-price-uah"));
            var pictures = document.QuerySelectorAll("img").Where(item => item.GetAttribute("width") == "240").Select(item => item.GetAttribute("src"));

            foreach (var item in nameItems)
            {
                Product itera = new Product();
                itera.Name = item.TextContent;
                productsList.Add(itera);
            }

            Product decsItera = productsList.First();
            int firstIndex = productsList.IndexOf(decsItera);
            int nextIndex = firstIndex;
            foreach (var item in descriptionItems)
            {
                if (nextIndex < productsList.Count)
                {
                    productsList[nextIndex].Description = item.TextContent;
                }
                nextIndex++;
            }
            nextIndex = 0;
            foreach (var item in pictures)
            {
                if (nextIndex < pictures.Count())
                {
                    if (nextIndex < productsList.Count)
                    {
                        productsList[nextIndex].Picture = item;
                    }
                }
                nextIndex++;
            }

            foreach (Product item in productsList)
            {
                Price itera = new Price();
                itera.Product = item;
                itera.ProductID = item.ProductID;
                itera.DateAdded = DateTime.Now;
                //Sometomes Rozetka don`t give it`s prices so easily
                itera.ProductPrice = "Error";
                priceList.Add(itera);                
            }
            Price priceItera = priceList.First();
            int firstIndexPrice = priceList.IndexOf(priceItera);
            int nextIndexPrice = firstIndexPrice;
           
            foreach (var item1 in priceItems)
            {
                if (nextIndexPrice < priceList.Count)
                {
                    priceList[nextIndex].ProductPrice = item1.TextContent;
                }
                nextIndexPrice++;
            }

            return list.ToArray();
        }
    }
}