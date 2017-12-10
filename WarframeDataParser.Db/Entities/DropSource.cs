using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Core.Metadata.Edm;
using System.Diagnostics;

namespace WarframeDataParser.Db.Entities {
    [DebuggerDisplay("DropSource {Name} ({DropSourceType?.Name}")]
    public abstract class DropSource : IDbItem {
        /// <inheritdoc />
        public long Id { get; set; }

        public string Name { get; set; }

        [ForeignKey(nameof(DropSourceType))]
        public long DropSourceTypeId { get; set; }

        public virtual DropSourceType DropSourceType { get; set; }

        public virtual ICollection<RewardDrop> RewardDrops { get; set; }

        public virtual Relic Relic { get; set; }
    }
}