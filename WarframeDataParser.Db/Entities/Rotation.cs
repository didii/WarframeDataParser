using System.Collections.Generic;

namespace WarframeDataParser.Db.Entities {
    public class Rotation : IDbItem {
        /// <inheritdoc />
        public long Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<RewardDrop> RewardDrops { get; set; }
    }
}