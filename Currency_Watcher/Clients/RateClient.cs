using System;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using Currency_Watcher.Dto;

namespace Currency_Watcher.Clients
{
    class RateClient
    {
        public void UsdRub(Action<string> callBack)
        {
            if (callBack == null)
                return;

            var request = (HttpWebRequest)WebRequest.Create("https://query.yahooapis.com/v1/public/yql?q=select+*+from+yahoo.finance.xchange+where+pair+=+%22USDRUB%22&format=json&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys&callback=");
            request.BeginGetResponse(asyncResult =>
                {
                    var result = FinishWebRequest(asyncResult);
                    var queryRoot = ParseUsdRub(result);
                    callBack(queryRoot.Query.Results.Rate.Rate);
                },
                request);
        }


        private static string FinishWebRequest(IAsyncResult asyncResult)
        {
            var request = (HttpWebRequest)asyncResult.AsyncState;
            var response = (HttpWebResponse)request.EndGetResponse(asyncResult);
            var streamResponse = response.GetResponseStream();
            var streamRead = new StreamReader(streamResponse);
            return streamRead.ReadToEnd();
        }

        private static QueryRoot ParseUsdRub(string json)
        {
            var serializer = new DataContractJsonSerializer(typeof(QueryRoot));
            return (QueryRoot)serializer.ReadObject(new MemoryStream(Encoding.UTF8.GetBytes(json)));
        }
    }
}
