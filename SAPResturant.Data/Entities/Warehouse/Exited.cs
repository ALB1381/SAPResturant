using SAPResturant.Data.Entities.Resturants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public int InventoryId { get; set; }
        [ForeignKey("InventoryId")]
        public Inventory Inventory { get; set; }
        public int BranchId { get; set; }
        [ForeignKey("BranchId")]
        public Branch Branch { get; set; }
    }
}
