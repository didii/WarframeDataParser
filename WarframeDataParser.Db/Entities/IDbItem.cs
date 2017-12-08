using System.ComponentModel.DataAnnotations;

namespace WarframeDataParser.Db.Entities {
    public interface IDbItem {
        /// <summary>
        /// The internal ID of this item
        /// </summary>
        [Key]
        long Id { get; set; }
    }
}
