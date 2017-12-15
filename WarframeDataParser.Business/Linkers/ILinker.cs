using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace WarframeDataParser.Business.Parsers {
    public interface ILinker {
        ILinkedInfo Parse(HtmlDocument document);
    }

    public interface ILinkedInfo {
        DateTime Start { get; }
        DateTime End { get; }
        TimeSpan Duration { get; }

        int RelationsChanged { get; }
    }
}
