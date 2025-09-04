using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPResturant.Data.Entities.Resturants.Menus
{
    public class Item
    {
        [Key]
        public int ItemId { get; set; }

        [MaxLength(50)]
        public string ItemName { get; set; }

        [MaxLength(200)]
        public string? ItemDescription { get; set; }
        [MaxLength(200)]
        public string? ItemIngrediants { get; set; }
        [MaxLength(200)]
        public string? ItemImage { get; set; }

        public int? ItemPrice { get; set; }

        public int ItemGroupId { get; set; }

        public int? ItemSubGroupId { get; set; }
        public int MenuId { get; set; }

        [ForeignKey("ItemGroupId")]
        public ItemGroup ItemGroup { get; set; }

        [ForeignKey("ItemSubGroupId")]
        public ItemGroup? ItemSubGroup { get; set; }

        public List<ItemModels>? ItemModels { get; set; }
        public List<ItemExteraConnection>? ItemExteraConnections { get; set; }

        [ForeignKey("MenuId")]
        public Menu Menu { get; set; }
    }
}
