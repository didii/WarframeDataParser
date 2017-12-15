using WarframeDataParser.Business.Selectors;

namespace WarframeDataParser.Business.Parsers {
    public interface IParser<T> where T : ISelection {
        EParseResult Parse(T selection);
    }
}