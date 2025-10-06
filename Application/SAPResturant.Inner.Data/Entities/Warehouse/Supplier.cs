using System.ComponentModel.DataAnnotations;

namespace SAPResturant.Inner.Data.Entities.Warehouse
{
    public class Supplier
    {
        [Key]
        public int SupplierId { get; set; }

        [MaxLength(50)]
        public string SupplierName { get; set; }

        [MaxLength(70)]
        public string? SupplierDescription { get; set; }

        [MaxLength(30)]
        public string SupplierPhoneNumber { get; set; }

        public DateTime? FirtSupply { get; set; }

        public List<Supplied>? Supplieds { get; set; }
        public List<Inventory>? Inventories { get; set; }

        [MaxLength(40)]
        public string MaderLog { get; set; }
    }
}