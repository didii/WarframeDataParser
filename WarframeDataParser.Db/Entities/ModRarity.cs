using System.Collections.Generic;

namespace WarframeDataParser.Db.Entities {
    internal class ModRarity : IDbItem {
        /// <inheritdoc />
        public long Id { get; set; }
        public int Value { get; set; }
        public string Name { get; set; }
        public ICollection<ModReward> ModRewards { get; set; }

    }
}