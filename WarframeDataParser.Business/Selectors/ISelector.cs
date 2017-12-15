using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace WarframeDataParser.Business.Selectors {
    public interface ISelector<T> where T : ISelection {
        IEnumerable<T> Select(HtmlDocument document);
    }
}
