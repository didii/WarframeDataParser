using System.Collections.Generic;
using HtmlAgilityPack;

namespace WarframeDataParser.Business.Selectors {
    interface ISelector {
        IEnumerable<string> Select(HtmlDocument document);
    }
}