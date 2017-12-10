using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace WarframeDataParser.Db.Entities {
    [DebuggerDisplay("Relic {RelicTier?.Name} {Name} ({RelicState?.Name})")]
    public class Relic : IDbItem {
        /// <inheritdoc />
        public long Id { get; set; }

        [ForeignKey(nameof(RelicTier))]
        public long RelicTierId { get; set; }

        public virtual RelicTier RelicTier { get; set; }

        [ForeignKey(nameof(RelicState))]
        public long RelicStateId { get; set; }

        public virtual RelicState RelicState { get; set; }

        [ForeignKey(nameof(Reward))]
        public long RewardId { get; set; }

        public virtual Reward Reward { get; set; }

        [ForeignKey(nameof(DropSource))]
        public long DropSourceId { get; set; }

        public virtual DropSource DropSource { get; set; }
    }
}