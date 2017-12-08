using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace WarframeDataParser.Db.Entities {
    [DebuggerDisplay("Reward {Name} ({RewardType?.Name})")]
    public class Reward : IDbItem {
        /// <inheritdoc />
        public long Id { get; set; }

        public string Name { get; set; }

        [ForeignKey(nameof(RewardType))]
        public long RewardTypeId { get; set; }

        public RewardType RewardType { get; set; }

        public ICollection<RewardDrop> RewardDrops { get; set; }

        #region Equality

        /// <inheritdoc />
        public override bool Equals(object obj) {
            if (!(obj is Reward reward))
                return false;
            return Name == reward.Name && Equals(RewardType, reward.RewardType);
        }

        protected bool Equals(Reward other) {
            return base.Equals(other) && string.Equals(Name, other.Name) && Equals(RewardType, other.RewardType);
        }

        /// <inheritdoc />
        public override int GetHashCode() {
            unchecked {
                int hashCode = base.GetHashCode();
                hashCode = (hashCode * 397) ^ (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (RewardType != null ? RewardType.GetHashCode() : 0);
                return hashCode;
            }
        }

        #endregion

    }
}