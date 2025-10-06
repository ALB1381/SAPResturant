using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAPResturant.Inner.Data.Entities.Menus.Connections
{
    public class ExtraOnItemItemConnection
    {
        [Key]
        public int ConnectionId { get; set; }

        public int ItemId { get; set; }

        public int ExtraOnItemId { get; set; }

        [ForeignKey("ItemId")]
        public Item Item { get; set; }

        [ForeignKey("ExtraOnItemId")]
        public ExtraOnItem ExtraOnItem { get; set; }

        [MaxLength(40)]
        public string MaderLog { get; set; }
    }
}
