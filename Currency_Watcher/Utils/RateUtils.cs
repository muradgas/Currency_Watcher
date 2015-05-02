using System;
using Currency_Watcher.Clients;
using Currency_Watcher.Parsers;

namespace Currency_Watcher.Utils
{
    public sealed class RateUtils : IRateUtils
    {
        private readonly IYahooApiClient _yahooApiClient;
        private readonly IXchangeParser _xchangeParser;

        public RateUtils(IYahooApiClient yahooApiClient, IXchangeParser xchangeParser)
        {
            _yahooApiClient = yahooApiClient;
            _xchangeParser = xchangeParser;
        }

        public void GetXchangeRate(string pair, Action<string> callBack)
        {
            if (callBack == null)
                return;

            _yahooApiClient.GetXchange(pair, result =>
                {
                    var queryRoot = _xchangeParser.Parse(result);
                    callBack(queryRoot.Query.Results.Rate.Rate);
                });
        }
    }
}
