using SAPResturant.Data.Entities.Resturants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAPResturant.Data.Entities.Warehouse
{
    public class Supplier
    {
        [Key]
        public long SupplierId { get; set; }

        [MaxLength(50)]
        public string SupplierName { get; set; }

        [MaxLength(70)]
        public string? SupplierDescription { get; set; }

        [MaxLength(30)]
        public string SupplierPhoneNumber { get; set; }

        public DateTime? FirtSupply { get; set; }

        public List<Supplied>? Supplieds { get; set; }
        public List<Inventory>? Inventories { get; set; }

        public int BranchId { get; set; }
        [ForeignKey("BranchId")]
        public Branch Branch { get; set; }
        


        [MaxLength(30)]
        public string OnMadeLog { get; set; }

    }
}