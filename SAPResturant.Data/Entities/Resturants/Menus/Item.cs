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
        #region Columns
        [Key]
        public long ItemId { get; set; }

        [MaxLength(50)]
        public string ItemName { get; set; }

        [MaxLength(200)]
        public string? ItemDescription { get; set; }
        [MaxLength(200)]
        public string? ItemIngrediants { get; set; }

        [MaxLength(100)]
        public string? ItemImage { get; set; }
        #endregion



        #region Rel
        public long ItemGroupId { get; set; }
        [ForeignKey("ItemGroupId")]
        public ItemGroup ItemGroup { get; set; }

        public long? ItemSubGroupId { get; set; }
        [ForeignKey("ItemSubGroupId")]
        public ItemGroup? ItemSubGroup { get; set; }


        public int MenuId { get; set; }
        [ForeignKey("MenuId")]
        public Menu Menu { get; set; }

        public int BranchId { get; set; }
        [ForeignKey("BranchId")]
        public Branch Branch { get; set; }

        public List<ItemModel>? ItemModels { get; set; }
        public List<ItemExteraConnection>? ItemExteraConnections { get; set; }
        #endregion



        [MaxLength(30)]
        public string OnMadeLog { get; set; }
    }
}
