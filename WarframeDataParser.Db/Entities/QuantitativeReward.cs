namespace WarframeDataParser.Db.Entities {
    internal class QuantitativeReward : Reward {
        public int Count { get; set; }

        /// <inheritdoc />
        public override bool Equals(object obj) {
            return base.Equals(obj) && Count == (obj as QuantitativeReward)?.Count;
        }

        protected bool Equals(QuantitativeReward other) {
            return base.Equals(other) && Count == other.Count;
        }

        /// <inheritdoc />
        public override int GetHashCode() {
            unchecked {
                return (base.GetHashCode() * 397) ^ Count;
            }
        }
    }
}