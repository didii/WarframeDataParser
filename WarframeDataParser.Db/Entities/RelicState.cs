using System.Collections.Generic;
using System.Diagnostics;

namespace WarframeDataParser.Db.Entities {
    [DebuggerDisplay("RelicState {Name} ({Value})")]
    internal class RelicState : IDbItem {
        /// <inheritdoc />
        public long Id { get; set; }

        public string Name { get; set; }
        public int Value { get; set; }
        public ICollection<Relic> Relic { get; set; }
    }
}