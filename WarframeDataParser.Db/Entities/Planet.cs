using System.Collections.Generic;
using System.Diagnostics;

namespace WarframeDataParser.Db.Entities {
    [DebuggerDisplay("Planet {Name}, Count = {Missions?.Count ?? 0}")]
    public class Planet : IDbItem {
        /// <inheritdoc />
        public long Id { get; set; }

        public string Name { get; set; }

        public ICollection<Mission> Missions { get; set; }

        #region Equality
        /// <inheritdoc />
        public override bool Equals(object obj) {
            if (!(obj is Planet planet))
                return false;
            return Name == planet.Name;
        }

        protected bool Equals(Planet other) {
            return string.Equals(Name, other.Name);
        }

        /// <inheritdoc />
        public override int GetHashCode() {
            return Name != null ? Name.GetHashCode() : 0;
        }
        #endregion

    }
}