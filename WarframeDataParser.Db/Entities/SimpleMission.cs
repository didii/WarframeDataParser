using System.Collections.Generic;
using System.Diagnostics;

namespace WarframeDataParser.Db.Entities {
    [DebuggerDisplay("SimpleMission {Name} ({MissionType?.Name})")]
    internal class SimpleMission : Mission {
        public ICollection<RewardDrop> Rewards { get; set; }
    }
}