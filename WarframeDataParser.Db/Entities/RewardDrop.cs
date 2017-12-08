using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace WarframeDataParser.Db.Entities {
    [DebuggerDisplay("RewardDrop {Reward?.Name} ({DropChance}%)")]
    public class RewardDrop : IDbItem  {
        /// <inheritdoc />
        public long Id { get; set; }

        [ForeignKey(nameof(Reward))]
        public long RewardId { get; set; }

        public Reward Reward { get; set; }

        public double DropChance { get; set; }

        public ICollection<DropSource> DropSources { get; set; }

    }
}