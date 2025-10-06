using SAPResturant.Data.Entities.Resturants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAPResturant.Data.Entities.Warehouse
{
    public class Exited
    {
        [Key]
        public long ExitedId { get; set; }

        public DateTime ExitedTime { get; set; }

        public int ExitedValue { get; set; }

        [MaxLength(100)]
        public string? Description { get; set; }
        public long? InventoryId { get; set; }
        [ForeignKey("InventoryId")]
        public Inventory? Inventory { get; set; }
        public int BranchId { get; set; }
        [ForeignKey("BranchId")]
        public Branch Branch { get; set; }


        [MaxLength(30)]
        public string OnMadeLog { get; set; }

    }
}
