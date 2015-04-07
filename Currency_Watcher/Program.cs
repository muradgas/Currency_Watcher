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
            string l,k;
            do
            {
                 l = m.USDRUB();
                 k = m.EURRUB();
                Thread.Sleep(1000);
                Console.Clear();
                Console.WriteLine("USDRUB = {0}", l);
                Console.WriteLine("EURRUB = {0}", k);
            }
            while (Console.KeyAvailable == false);
        }
    }
}
