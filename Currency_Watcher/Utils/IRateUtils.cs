using System;

namespace Currency_Watcher.Utils
{
    public interface IRateUtils
    {
        void GetXchangeRate(string pair, Action<string> callback);
    }
}
