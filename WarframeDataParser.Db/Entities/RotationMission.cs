using System.Diagnostics;

namespace WarframeDataParser.Db.Entities {
    [DebuggerDisplay("RotationMission {Name} ({MissionType?.Name})")]
    internal class RotationMission : Mission {
        public MissionRotations MissionRotations { get; set; }
    }
}