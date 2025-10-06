using SAPResturant.Data.Entities.Resturants;
using SAPResturant.Data.Entities.Warehouse.Connection;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAPResturant.Data.Entities.Warehouse
{
    public class Inventory
    {
        [Key]
        public long InventoryId { get; set; }

        [MaxLength(100)]
        public string InventoryName { get; set; }

        [MaxLength(300)]
        public string? InventoryDescription { get; set; }

        [MaxLength(20)]
        public string InventoryUnit { get; set; }

        public int? ValueInStock { get; set; }

        public int? ChangeToNearToDoneValue { get; set; }

        public int? InventoryGroupId { get; set; }
        [ForeignKey("InventoryGroupId")]
        public InventoryGroup? InventoryGroup { get; set; }

        public long? SupplierId { get; set; }
        [ForeignKey("SupplierId")]
        public Supplier? Supplier { get; set; }
        public int? InventoryStatusId { get; set; }
        [ForeignKey("InventoryStatusId")]
        public InventoryStatus? InventoryStatus { get; set; }
        public List<Exited>? Exiteds { get; set; }
        public List<Supplied>? Supplieds { get; set; }
        public List<ItemModelInventoryConnection>? ItemCaseInventoryConnections { get; set; }

        public int BranchId { get; set; }
        [ForeignKey("BranchId")]
        public Branch Branch { get; set; }



        [MaxLength(30)]
        public string OnMadeLog { get; set; }

    }
}
