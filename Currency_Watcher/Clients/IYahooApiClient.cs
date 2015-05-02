using System;

namespace Currency_Watcher.Clients
{
    public interface IYahooApiClient
    {
        void GetXchange(string pair, Action<string> callBack);
    }
}