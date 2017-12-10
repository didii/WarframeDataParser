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

        public virtual Reward Reward { get; set; }

        public double DropChance { get; set; }

        public int Count { get; set; }

        public virtual Rotation Rotation { get; set; }

        public virtual DropSource DropSources { get; set; }
    }
}