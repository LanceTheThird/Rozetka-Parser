
namespace WebApplication1.Models.Core.Shop
{
    public class ShopSettings : IParserSettings
    {
        public ShopSettings(int start, int end)
        {
            StartPoint = start;
            EndPoint = end;
        }
        public string BaseUrl { get; set; } = "https://rozetka.com.ua/notebooks/c80004/filter/";

        public int EndPoint { get; set; }

        public string Prefix { get; set; } = "page={CurrentId}/";

        public int StartPoint { get; set; }

    }
}