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

        #region Equality

        /// <inheritdoc />
        public override bool Equals(object obj) {
            if (!(obj is Mission mission))
                return false;
            return Name == mission.Name && Equals(Planet, mission.Planet);
        }

        protected bool Equals(Mission other) {
            return base.Equals(other) && string.Equals(Name, other.Name) && Equals(Planet, other.Planet);
        }

        /// <inheritdoc />
        public override int GetHashCode() {
            unchecked {
                int hashCode = base.GetHashCode();
                hashCode = (hashCode * 397) ^ (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Planet != null ? Planet.GetHashCode() : 0);
                return hashCode;
            }
        }

        #endregion
    }
}