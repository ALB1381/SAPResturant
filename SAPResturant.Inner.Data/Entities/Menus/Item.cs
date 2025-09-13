using SAPResturant.Inner.Data.Entities.Menus.Connections;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPResturant.Inner.Data.Entities.Menus
{
    public class Item
    {
        [Key]
        public int ItemId { get; set; }

        [MaxLength(50)]
        public string ItemName { get; set; }

        [MaxLength(300)]
        public string? ItemDescription { get; set; }

        [MaxLength(300)]
        public string? ItemIngrediants { get; set; }

        [MaxLength(100)]
        public string? ItemImage { get; set; }

        public int ItemGroupId { get; set; }
        [ForeignKey("ItemGroupId")]
        public ItemGroup ItemGroup { get; set; }

        public List<ItemCase>? ItemCases { get; set; }
        public List<ExtraOnItemItemConnection>? ExtraOnItemItemConnections { get; set; }

        [MaxLength(40)]
        public string MaderLog { get; set; }
    }
}
