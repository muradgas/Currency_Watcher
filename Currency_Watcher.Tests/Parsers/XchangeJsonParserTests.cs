
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
            var parser = new XchangeJsonParser();
            const string serialized = "{\"query\":{\"count\":1,\"created\":\"2015-05-06T08:39:14Z\",\"lang\":\"ru-RU\",\"results\":{\"rate\":{\"id\":\"USDRUB\",\"Name\":\"USD/RUB\",\"Rate\":\"51.9595\",\"Date\":\"5/6/2015\",\"Time\":\"9:39am\",\"Ask\":\"49.8960\",\"Bid\":\"49.8860\"}}}}";
            var result = parser.Parse(serialized);
            Assert.AreEqual("51.9595", result.Query.Results.Rate.Rate);
        }
    }
}