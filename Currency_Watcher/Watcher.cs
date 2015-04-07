using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Net;

namespace Currency_Watcher
{
    class Watcher
    {

        int i;
        string s;
        public string USDRUB()
        {
            try
                { 
            
                    HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create("https://query.yahooapis.com/v1/public/yql?q=select+*+from+yahoo.finance.xchange+where+pair+=+%22USDRUB,EURRUB%22&format=json&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys&callback=");
                    HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
                    using (StreamReader stream = new StreamReader(resp.GetResponseStream(), Encoding.UTF8))
                    s = stream.ReadToEnd();
                    for (i = 0; i != s.Length - 7; i++)
                        {
                            if (string.Concat(s[i], s[i + 1], s[i + 2], s[i + 3], s[i + 4], s[i + 5], s[i + 6]).Equals("USD/RUB"))
                            return string.Concat(s[i + 17], s[i + 18], s[i + 19], s[i + 20], s[i + 21], s[i + 22], s[i + 23]);
                        }
                }
             catch (Exception)
                {
                    Console.WriteLine("Error");
                }  
             return "Error";

        }
        public string EURRUB()
        {
            try
            {

                HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create("https://query.yahooapis.com/v1/public/yql?q=select+*+from+yahoo.finance.xchange+where+pair+=+%22USDRUB,EURRUB%22&format=json&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys&callback=");
                HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
                using (StreamReader stream = new StreamReader(resp.GetResponseStream(), Encoding.UTF8))
                    s = stream.ReadToEnd();
                for (i = 0; i != s.Length - 7; i++)
                {
                    if (string.Concat(s[i], s[i + 1], s[i + 2], s[i + 3], s[i + 4], s[i + 5], s[i + 6]).Equals("EUR/RUB"))
                        return string.Concat(s[i + 17], s[i + 18], s[i + 19], s[i + 20], s[i + 21], s[i + 22], s[i + 23]);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error");
            }
            return "Error";
        }
    }
}
