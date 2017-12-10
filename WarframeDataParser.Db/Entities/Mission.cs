using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace WarframeDataParser.Db.Entities {
    [DebuggerDisplay("Mission {Name} ({MissionType?.Name})")]
    public class Mission : DropSource {
        [ForeignKey(nameof(MissionType))]
        public long MissionTypeId { get; set; }

        public virtual MissionType MissionType { get; set; }

        [ForeignKey(nameof(Planet))]
        public long PlanetId { get; set; }

        public virtual Planet Planet { get; set; }
    }
}