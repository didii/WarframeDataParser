using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WarframeDataParser.Db.Entities {
    internal class ModReward : Reward {
        [ForeignKey(nameof(ModRarity))]
        public long ModRarityId { get; set; }

        public ModRarity ModRarity { get; set; }

        public ICollection<DropSource> DropSources { get; set; }
    }
}