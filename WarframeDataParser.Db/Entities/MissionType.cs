using System.Collections.Generic;
using System.Diagnostics;

namespace WarframeDataParser.Db.Entities {
    [DebuggerDisplay("MissionType {Name}")]
    public class MissionType : IDbItem {
        /// <inheritdoc />
        public long Id { get; set; }

        public string Name { get; set; }

        public ICollection<Mission> Missions { get; set; }

        #region Equality

        /// <inheritdoc />
        public override bool Equals(object obj) {
            if (!(obj is MissionType missionType))
                return false;
            return Name == missionType.Name;
        }

        protected bool Equals(MissionType other) {
            return base.Equals(other) && string.Equals(Name, other.Name);
        }

        /// <inheritdoc />
        public override int GetHashCode() {
            unchecked {
                return (base.GetHashCode() * 397) ^ (Name != null ? Name.GetHashCode() : 0);
            }
        }

        #endregion
    }
}