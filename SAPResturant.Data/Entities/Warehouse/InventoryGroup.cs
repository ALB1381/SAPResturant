using System.ComponentModel.DataAnnotations;

namespace SAPResturant.Data.Entities.Warehouse
{
    public class InventoryGroup
    {
        [Key]
        public int InventoryGroupId { get; set; }

        [MaxLength(30)]
        public string? GroupName { get; set; }

        public List<Inventory> Inventories { get; set; }


        [MaxLength(30)]
        public string OnMadeLog { get; set; }

    }
}