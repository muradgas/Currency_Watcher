using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Currency_Watcher
{
    class Program
    {
        static void Main(string[] args)
        {
            var m = new Watcher();
            do
            {
                Console.WriteLine("USDRUB = {0}", m.USDRUB());
                Console.WriteLine("EURRUB = {0}", m.EURRUB());
                Thread.Sleep(1000);
                Console.Clear();
            }
            while (Console.KeyAvailable == false);
        }
    }
}
