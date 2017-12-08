using System.Collections.Generic;
using System.Diagnostics;

namespace WarframeDataParser.Db.Entities {
    [DebuggerDisplay("DropSourceType {Name}")]
    public class DropSourceType : IDbItem {
        /// <inheritdoc />
        public long Id { get; set; }
        public string Name { get; set; }
        public ICollection<DropSource> DropSources { get; set; }

    }
}