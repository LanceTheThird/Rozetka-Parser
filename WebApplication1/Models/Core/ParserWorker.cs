using AngleSharp.Parser.Html;
using System;
using System.Threading.Tasks;
using WebApplication1.Models.DataAccess;

namespace WebApplication1.Models.Core
{
    public class ParserWorker<T> where T : class
    {
        IParser<T> parser;
        IParserSettings parserSettings;
        HtmlLoader loader;
        bool isActive;

        #region Properties

        public event Action<object, T> OnNewData;
        public event Action<object> OnCompleted;
        public IParser<T> Parser
        {
            get
            {
                return parser;
            }
            set
            {
                parser = value;
            }
        }

        public IParserSettings Settings
        {
            get
            {
                return parserSettings;
            }
            set
            {
                parserSettings = value;
                loader = new HtmlLoader(value);
            }
        }

        public bool IsActive
        {
            get
            {
                return isActive;
            }
        }
        #endregion
        public ParserWorker(IParser<T> parser)
        {
            this.parser = parser;
        }

        public ParserWorker(IParser<T> parser, IParserSettings parserSettings) : this(parser)
        {
            this.parserSettings = parserSettings;
            loader = new HtmlLoader(parserSettings);
        }

        public async Task<string> Worker(CodeContext context)
        {
            isActive = true;
            for (int i = parserSettings.StartPoint; i <= parserSettings.EndPoint; i++)
            {
                if(!isActive)
                {
                    OnCompleted?.Invoke(this);
                    return null;
                }

                var source = await loader.GetSourceByPageId(i);
                var domParser = new HtmlParser();

                var document = await domParser.ParseAsync(source);

                var result = parser.Parse(document);
                
                    //Database.SetInitializer(new Init());
                    foreach (Product attendee in parser.ProductsList)
                    {
                        context.Products.Add(attendee);
                    }

                foreach (Price attendee in parser.PricesList)
                {
                    context.Prices.Add(attendee);
                }

                try
                {
                    context.SaveChanges();
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
                {
                    Exception raise = dbEx;
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            string message = string.Format("{0}:{1}",
                                validationErrors.Entry.Entity.ToString(),
                                validationError.ErrorMessage);
                            // raise a new exception nesting
                            // the current instance as InnerException
                            raise = new InvalidOperationException(message, raise);
                        }
                    }
                    throw raise;
                }

                OnNewData?.Invoke(this, result);
            }
            OnCompleted?.Invoke(this);
            isActive = false;
            return await loader.GetSourceByPageId(1);
        }
    }
}