using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using Currency_Watcher.Dto;

namespace Currency_Watcher.Parsers
{
    public class XchangeJsonParser : IXchangeParser
    {
        public QueryRoot Parse(string serialized)
        {
            var serializer = new DataContractJsonSerializer(typeof(QueryRoot));
            return (QueryRoot)serializer.ReadObject(new MemoryStream(Encoding.UTF8.GetBytes(serialized)));
        }
    }
}