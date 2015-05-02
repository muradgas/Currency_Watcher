using Currency_Watcher.Dto;

namespace Currency_Watcher.Parsers
{
    public interface IXchangeParser
    {
        QueryRoot Parse(string serialized);
    }
}
