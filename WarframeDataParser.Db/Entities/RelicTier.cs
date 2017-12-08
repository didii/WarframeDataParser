using System.Collections.Generic;
using System.Diagnostics;

namespace WarframeDataParser.Db.Entities {
    [DebuggerDisplay("RelicTier {Name} ({Value})")]
    internal class RelicTier : IDbItem {
        /// <inheritdoc />
        public long Id { get; set; }

        public int Value { get; set; }
        public string Name { get; set; }

        public ICollection<Relic> Relics { get; set; }

        #region Equality
        /// <inheritdoc />
        public override bool Equals(object obj) {
            if (!(obj is RelicTier tier))
                return false;
            return Value == tier.Value && Name == tier.Name;
        }

        protected bool Equals(RelicTier other) {
            return base.Equals(other) && Value == other.Value && string.Equals(Name, other.Name);
        }

        /// <inheritdoc />
        public override int GetHashCode() {
            unchecked {
                int hashCode = Name?.GetHashCode() ?? 0;
                hashCode = (hashCode * 397) ^ Value;
                return hashCode;
            }
        }
        #endregion

    }
}