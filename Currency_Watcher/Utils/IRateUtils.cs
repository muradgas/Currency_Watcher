using System;

namespace Currency_Watcher.Clients
{
    public interface IRateUtils
    {
        void GetXchangeRate(string pair, Action<string> callback);
    }
}
