using System.Collections.Generic;
using System.Diagnostics;

namespace WarframeDataParser.Db.Entities {
    [DebuggerDisplay("RelicTier {Name} ({Value})")]
    internal class RelicTier : IDbItem {
        /// <inheritdoc />
        public long Id { get; set; }

        public int Value { get; set; }
        public string Name { get; set; }

        public ICollection<Relic> Relics { get; set; }
    }
}