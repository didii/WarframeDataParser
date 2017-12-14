using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace WarframeDataParser.Business.Selectors {
    interface IRewardSelector {
        IEnumerable<IRewardSelection> Select(HtmlDocument document);
    }
}
