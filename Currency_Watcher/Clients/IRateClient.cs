using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Currency_Watcher.Dto;

namespace Currency_Watcher.Clients
{
    public interface IRateClient
    {
        void UsdRub(Action<string> callback);
        string FinishWebRequest(IAsyncResult asyncResult);
        QueryRoot ParseUsdRub(string json);
    }
}
