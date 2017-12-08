using System.Collections.Generic;

namespace WarframeDataParser.Db.Entities {
    public class Enemy : DropSource {
        public ICollection<RewardDrop> RewardDrops { get; set; }
    }
}