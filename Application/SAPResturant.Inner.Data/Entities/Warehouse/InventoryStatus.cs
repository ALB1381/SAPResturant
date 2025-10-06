using System.ComponentModel.DataAnnotations;

namespace SAPResturant.Inner.Data.Entities.Warehouse
{
    public class InventoryStatus
    {
        [Key]
        public int InventoryStatusId { get; set; }

        [MaxLength(70)]
        public string StatusName { get; set; }

        [MaxLength(60)]
        public string? StatusColor { get; set; }

        public List<Inventory>? Inventories { get; set; }

        [MaxLength(40)]
        public string MaderLog { get; set; }
    }
}