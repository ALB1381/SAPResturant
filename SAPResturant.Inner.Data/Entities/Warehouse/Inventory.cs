using SAPResturant.Inner.Data.Entities.Menus;
using SAPResturant.Inner.Data.Entities.Warehouse.Connection;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPResturant.Inner.Data.Entities.Warehouse
{
    public class Inventory
    {
        [Key]
        public int InventoryId { get; set; }

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

        public int? SupplierId { get; set; }
        [ForeignKey("SupplierId")]
        public Supplier? Supplier { get; set; }
        public int? InventoryStatusId { get; set; }
        [ForeignKey("InventoryStatusId")]
        public InventoryStatus? InventoryStatus { get; set; }
        public List<Exited>? Exiteds { get; set; }
        public List<Supplied>? Supplieds { get; set; }

        public List<ItemCaseInventoryConnection>? ItemCaseInventoryConnections { get; set; }
    }
}
