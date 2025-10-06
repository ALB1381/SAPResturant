using SAPResturant.Data.Entities.Resturants;
using SAPResturant.Data.Entities.Resturants.Menus;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAPResturant.Data.Entities.Warehouse.Connection
{
    public class ItemModelInventoryConnection
    {
        [Key]
        public long ConnectionId { get; set; }

        public long InventoryId { get; set; }
        public long ItemCaseId { get; set; }

        [ForeignKey("InventoryId")]
        public Inventory Inventory { get; set; }

        [ForeignKey("ItemCaseId")]
        public ItemModel ItemModel { get; set; }

        public int BranchId { get; set; }
        [ForeignKey("BranchId")]
        public Branch Branch { get; set; }



        [MaxLength(30)]
        public string OnMadeLog { get; set; }

    }
}
