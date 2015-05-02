using System;
using Currency_Watcher.Clients;
using Currency_Watcher.Dto;
using Currency_Watcher.Parsers;
using Currency_Watcher.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Currency_Watcher.Tests.Utils
{
    [TestClass]
    public class RateUtilsTests
    {
        [TestMethod]
        public void Get()
        {
            var yahooApiClient = new Mock<IYahooApiClient>();
            var xchangeParser = new Mock<IXchangeParser>();
            var utils = new RateUtils(yahooApiClient.Object, xchangeParser.Object);

            yahooApiClient.Setup(client => client.GetXchange("myPair", It.IsAny<Action<string>>()))
                .Callback<String, Action<string>>((pair, callBack) => callBack("myJson"));

            var queryRoot = new QueryRoot
            {
                Query = new Query
                {
                    Results = new Results
                    {
                        Rate = new RateDetails
                        {
                            Rate = "123.45"
                        }
                    }
                }
            };

            xchangeParser.Setup(parser => parser.Parse("myJson")).Returns(queryRoot);

            utils.GetXchangeRate(
                "myPair",
                rate => Assert.AreEqual("123.45", rate));
        }
    }
}