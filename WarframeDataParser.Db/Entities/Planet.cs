using System.Collections.Generic;
using System.Diagnostics;

namespace WarframeDataParser.Db.Entities {
    [DebuggerDisplay("Planet {Name}, Count = {Missions?.Count ?? 0}")]
    public class Planet : IDbItem {
        /// <inheritdoc />
        public long Id { get; set; }

        public string Name { get; set; }

        public ICollection<Mission> Missions { get; set; }
    }
}