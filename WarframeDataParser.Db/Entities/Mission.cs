using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace WarframeDataParser.Db.Entities {
    [DebuggerDisplay("Mission {Name} ({MissionType?.Name})")]
    public abstract class Mission : DropSource {
        [ForeignKey(nameof(MissionType))]
        public long MissionTypeId { get; set; }

        public MissionType MissionType { get; set; }

        [ForeignKey(nameof(Planet))]
        public long PlanetId { get; set; }

        public Planet Planet { get; set; }
    }
}