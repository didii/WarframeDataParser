using System.Collections.Generic;
using WarframeDataParser.Business.Selectors;
using WarframeDataParser.Db.Entities;

namespace WarframeDataParser.Business.Parsers {
    interface IRewardParser {
        bool Parse(IRewardSelection selection);
    }
}