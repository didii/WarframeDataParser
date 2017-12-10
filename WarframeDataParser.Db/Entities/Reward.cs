using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace WarframeDataParser.Db.Entities {
    [DebuggerDisplay("Reward {Name} ({RewardType?.Name})")]
    public class Reward : IDbItem {
        /// <inheritdoc />
        public long Id { get; set; }

        public string Name { get; set; }

        [ForeignKey(nameof(RewardType))]
        public long RewardTypeId { get; set; }

        public virtual RewardType RewardType { get; set; }

        public virtual ICollection<RewardDrop> RewardDrops { get; set; }

        public virtual Relic Relic { get; set; }
    }
}