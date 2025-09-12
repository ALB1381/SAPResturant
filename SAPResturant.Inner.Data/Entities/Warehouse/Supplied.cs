using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPResturant.Inner.Data.Entities.Warehouse
{
    public class Supplied
    {
        [Key]
        public int Id { get; set; }

        public DateTime SuppliedDate { get; set; }

        public int Value { get; set; }

        public int? SinglePrice { get; set; }
        public int? TotalPrice { get; set; }

        [MaxLength(100)]
        public string? Description { get; set; }

        public int InventoryId { get; set; }
        [ForeignKey("InventoryId")]
        public Inventory Inventory { get; set; }

        public int SupplierId { get; set; }
        [ForeignKey("SupplierId")]
        public Supplier Supplier { get; set; }

    }
}
