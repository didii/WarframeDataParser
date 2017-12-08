using System.Collections.Generic;
using System.Diagnostics;

namespace WarframeDataParser.Db.Entities {
    [DebuggerDisplay("RewardType {Name}")]
    public class RewardType : IDbItem {
        /// <inheritdoc />
        public long Id { get; set; }

        public string Name { get; set; }

        public ICollection<Reward> Rewards { get; set; }

        #region Equality

        /// <inheritdoc />
        public override bool Equals(object obj) {
            if (!(obj is RewardType rewardType))
                return false;
            return Name == rewardType.Name;
        }

        protected bool Equals(RewardType other) {
            return base.Equals(other) && string.Equals(Name, other.Name);
        }

        /// <inheritdoc />
        public override int GetHashCode() {
            return Name != null ? Name.GetHashCode() : 0;
        }

        #endregion

    }
}