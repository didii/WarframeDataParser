using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace WarframeDataParser.Db.Entities {
    [DebuggerDisplay("Relic {RelicTier?.Name} {Name} ({RelicState?.Name})")]
    internal class Relic : Reward {
        [ForeignKey(nameof(RelicTier))]
        public long RelicTierId { get; set; }

        public RelicTier RelicTier { get; set; }

        public RelicState RelicState { get; set; }

        public ICollection<Reward> Rewards { get; set; }

        #region Equality

        /// <inheritdoc />
        public override bool Equals(object obj) {
            return base.Equals(obj) && Equals(RelicTier, (obj as Relic)?.RelicTier);
        }

        protected bool Equals(Relic other) {
            return base.Equals(other) && Equals(RelicTier, other.RelicTier);
        }

        /// <inheritdoc />
        public override int GetHashCode() {
            unchecked {
                return (base.GetHashCode() * 397) ^ (RelicTier != null ? RelicTier.GetHashCode() : 0);
            }
        }

        #endregion
    }
}