using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Currency_Watcher.Clients;
using System.Net;
using System.IO;
using System.Text;
using System.Runtime.Serialization;

namespace RateClientTest
{
    [TestClass]
    public class RateClientTests
    {
        IAsyncResult asyncResult;
        [TestMethod]
        public void RateClientTest()
        {
            //объявляем все что нужно и что не нужно
            var rateclient = new Mock<IRateClient>();
            var Module = new Module(rateclient.Object);
           // var _rate = new RateClient(); возможно не нужно
            // значение для заглушки
            string text = "{\"query\":{\"count\":1,\"created\":\"2015-05-02T15:07:42Z\",\"lang\":\"ru-RU\",\"results\":{\"rate\":{\"id\":\"USDRUB\",\"Name\":\"USD/RUB\",\"Rate\":\"51.9595\",\"Date\":\"5/2/2015\",\"Time\":\"12:55pm\",\"Ask\":\"52.1400\",\"Bid\":\"51.9595\"}}}}";
            // заглушка
            rateclient.Setup(rc => rc.FinishWebRequest(asyncResult)).Returns(text);
            var request = (HttpWebRequest)WebRequest.Create("https://query.yahooapis.com/v1/public/yql?q=select+*+from+yahoo.finance.xchange+where+pair+=+%22USDRUB%22&format=json&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys&callback=");
            request.BeginGetResponse(asyncResult =>
                {
                    var result = Module.FWR(asyncResult); // здесь внутри метода вызывается FinishWebRequest и должно вернуть значение text
                    //var queryRoot = _rate.ParseUsdRub(result); хз парсить реальным или виртуальным, поэтому закомментил этот вариант
                    var queryRoot = Module.ParseUsdRub(result);// парсим то что вернули
                    Assert.AreEqual("51.9595",queryRoot.Query.Results.Rate.Rate);// сравниваем
                },
                request);
        }
        
    }
}
