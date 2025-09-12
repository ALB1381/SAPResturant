using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPResturant.Inner.Data.Entities.Warehouse
{
    public class InventoryGroup
    {
        [Key]
        public int InventoryGroupId { get; set; }

        [MaxLength(30)]
        public string? GroupName { get; set; }

        public List<Inventory> Inventories { get; set; }
    }
}
