using System.Collections.Generic;
using System.Diagnostics;

namespace WarframeDataParser.Db.Entities {
    [DebuggerDisplay("MissionRotations \\{A[{A?.Count ?? 0}], B[{B?.Count ?? 0}], C[{C?.Count ?? 0}]\\}")]
    internal class MissionRotations : IDbItem {
        /// <inheritdoc />
        public long Id { get; set; }
        public ICollection<RewardDrop> A { get; set; }
        public ICollection<RewardDrop> B { get; set; }
        public ICollection<RewardDrop> C { get; set; }
        public ICollection<RotationMission> EndlessMissions { get; set; }

    }
}