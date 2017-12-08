using System.Collections.Generic;
using System.Diagnostics;

namespace WarframeDataParser.Db.Entities {
    [DebuggerDisplay("MissionType {Name}")]
    public class MissionType : IDbItem {
        /// <inheritdoc />
        public long Id { get; set; }

        public string Name { get; set; }

        public ICollection<Mission> Missions { get; set; }
    }
}