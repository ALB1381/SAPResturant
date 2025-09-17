using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPResturant.Data.Entities.Resturants.Menus
{
    public class Menu
    {
        [Key]
        public int MenuId { get; set; }

        public int BranchId { get; set; }

        public List<ItemGroup> ItemGroups { get; set; }
        public List<Item> Items { get; set; }

        [ForeignKey("BranchId")]
        public Branch Branch { get; set; }

        public List<ItemDiscount>? ItemDiscounts { get; set; }
    }
}
