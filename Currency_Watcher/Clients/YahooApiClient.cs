using System;
using System.IO;
using System.Net;

namespace Currency_Watcher.Clients
{
    class YahooApiClient : IYahooApiClient
    {
        public void GetXchange(string pair, Action<string> callBack)
        {
            if (callBack == null)
                return;

            var request = (HttpWebRequest)WebRequest.Create("https://query.yahooapis.com/v1/public/yql?q=select+*+from+yahoo.finance.xchange+where+pair+=+%22" + pair + "%22&format=json&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys&callback=");
            request.BeginGetResponse(asyncResult =>
                {
                    var result = FinishWebRequest(asyncResult);
                    callBack(result);
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
    }
}