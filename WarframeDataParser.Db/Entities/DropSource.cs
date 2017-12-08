using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace WarframeDataParser.Db.Entities {
    [DebuggerDisplay("DropSource {Name} ({DropSourceType?.Name}")]
    public abstract class DropSource : IDbItem {
        /// <inheritdoc />
        public long Id { get; set; }

        public string Name { get; set; }

        [ForeignKey(nameof(DropSourceType))]
        public long DropSourceTypeId { get; set; }

        public DropSourceType DropSourceType { get; set; }

        public ICollection<RewardDrop> RewardDrops { get; set; }
    }
}