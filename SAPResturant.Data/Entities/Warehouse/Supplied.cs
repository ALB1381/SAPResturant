using SAPResturant.Data.Entities.Resturants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAPResturant.Data.Entities.Warehouse
{
    public class Supplied
    {
        [Key]
        public long Id { get; set; }

        public DateTime SuppliedDate { get; set; }

        public int Value { get; set; }

        public int? SinglePrice { get; set; }
        public int? TotalPrice { get; set; }

        [MaxLength(100)]
        public string? Description { get; set; }

        public long? InventoryId { get; set; }
        [ForeignKey("InventoryId")]
        public Inventory? Inventory { get; set; }

        public long? SupplierId { get; set; }
        [ForeignKey("SupplierId")]
        public Supplier? Supplier { get; set; }

        public int BranchId { get; set; }

        [ForeignKey("BranchId")]
        public Branch Branch { get; set; }


        [MaxLength(30)]
        public string OnMadeLog { get; set; }

    }
}