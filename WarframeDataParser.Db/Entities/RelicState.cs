using System.Collections.Generic;
using System.Diagnostics;

namespace WarframeDataParser.Db.Entities {
    [DebuggerDisplay("RelicState {Name} ({Value})")]
    public class RelicState : IDbItem {
        /// <inheritdoc />
        public long Id { get; set; }

        public string Name { get; set; }

        public int Value { get; set; }

        public virtual ICollection<Relic> Relic { get; set; }
    }
}