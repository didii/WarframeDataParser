using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace WarframeDataParser.Db.Entities {
    [DebuggerDisplay("Relic {RelicTier?.Name} {Name} ({RelicState?.Name})")]
    internal class Relic : Reward {
        [ForeignKey(nameof(RelicTier))]
        public long RelicTierId { get; set; }

        public RelicTier RelicTier { get; set; }

        public RelicState RelicState { get; set; }

        public ICollection<RewardDrop> RewardDrops { get; set; }
    }
}