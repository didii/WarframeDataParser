using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace WarframeDataParser.Business.Fetcher {
    interface IDataFetcher {
        HtmlDocument Fetch(string uri = null);
    }
}
