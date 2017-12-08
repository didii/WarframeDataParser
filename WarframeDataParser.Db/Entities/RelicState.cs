using System.Collections.Generic;
using System.Diagnostics;

namespace WarframeDataParser.Db.Entities {
    [DebuggerDisplay("RelicState {Name} ({Value})")]
    internal class RelicState : IDbItem {
        /// <inheritdoc />
        public long Id { get; set; }

        public string Name { get; set; }
        public int Value { get; set; }
        public ICollection<Relic> Relic { get; set; }

        #region Equality

        public override bool Equals(object obj) {
            return obj is RelicState state && Name == state.Name && Value == state.Value;
        }

        public override int GetHashCode() {
            var hashCode = -244751520;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + Value.GetHashCode();
            return hashCode;
        }

        #endregion

    }
}