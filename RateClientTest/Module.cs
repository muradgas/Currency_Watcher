using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Currency_Watcher.Clients;
using Currency_Watcher.Dto;

namespace RateClientTest
{
    //класс для взаимодействия мока и методов интерфейса. Конструктор или как там его=)
    public class Module
    {
        private readonly IRateClient _rate;
        // метод асинхронного запроса
        public string FWR (IAsyncResult _async)
        {
            return _rate.FinishWebRequest(_async);
        }
        // парсер
        public QueryRoot ParseUsdRub(string json)
        {
            return _rate.ParseUsdRub(json);
        }
        //конструктор?
        public Module(IRateClient rate)
        {
            _rate = rate;
        }

    }
}
