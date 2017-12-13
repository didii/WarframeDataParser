using WarframeDataParser.Db.Entities;

namespace WarframeDataParser.Business.Parsers {
    interface IRewardParser {
        bool Parse(string name, RewardContext context);
    }
}