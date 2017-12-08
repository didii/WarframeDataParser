using System.Collections.Generic;
using System.Diagnostics;

namespace WarframeDataParser.Db.Entities {
    [DebuggerDisplay("RewardType {Name}")]
    public class RewardType : IDbItem {
        /// <inheritdoc />
        public long Id { get; set; }

        public string Name { get; set; }

        public ICollection<Reward> Rewards { get; set; }
    }
}