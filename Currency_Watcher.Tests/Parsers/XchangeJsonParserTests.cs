using Currency_Watcher.Parsers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Currency_Watcher.Tests.Parsers
{
    [TestClass]
    public class XchangeJsonParserTests
    {
        [TestMethod]
        public void ParseTest()
        {
            /* Тест не работает. Не может найти библиотеку 'System.ServiceModel.Web, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e'
            var parser = new XchangeJsonParser();
            const string serialized = @"https://query.yahooapis.com/v1/public/yql?q=select+*+from+yahoo.finance.xchange+where+pair+=+%22USDRUB%22&format=json&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys&callback=";
            var result = parser.Parse(serialized);
            Assert.AreEqual("51.9595", result.Query.Results.Rate.Rate);
             */
        }
    }
}