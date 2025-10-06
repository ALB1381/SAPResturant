using SAPResturant.Inner.Data.Entities.Menus;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAPResturant.Inner.Data.Entities.Warehouse.Connection
{
    public class ItemCaseInventoryConnection
    {
        [Key]
        public int ConnectionId { get; set; }

        public int InventoryId { get; set; }
        public int ItemCaseId { get; set; }

        [ForeignKey("InventoryId")]
        public Inventory Inventory { get; set; }

        [ForeignKey("ItemCaseId")]
        public ItemCase ItemCase { get; set; }

        [MaxLength(40)]
        public string MaderLog { get; set; }
    }
}
