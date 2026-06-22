using SAPResturant.Inner.Data.Entities.Menus.Connections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAPResturant.Inner.Data.Entities.Menus
{
    public class Item
    {
        #region Columns
        [Key]
        public int ItemId { get; set; }

        [MaxLength(50)]
        public string ItemName { get; set; }

        [MaxLength(300)]
        public string? ItemDescription { get; set; }

        [MaxLength(300)]
        public string? ItemIngrediants { get; set; }

        public int ItemUnitId { get; set; }

        [MaxLength(100)]
        public string? ItemImage { get; set; }
        #endregion


        #region Rel
        [ForeignKey("ItemUnitId")]
        public ItemUnit ItemUnit { get; set; }
        public int ItemGroupId { get; set; }
        [ForeignKey("ItemGroupId")]
        public ItemGroup ItemGroup { get; set; }

        public int? ItemSubGroupId { get; set; }

        [ForeignKey("ItemSubGroupId")]
        public ItemGroup? ItemSubGroup { get; set; }

        public List<ItemCase>? ItemCases { get; set; }
        public List<ExtraOnItemItemConnection>? ExtraOnItemItemConnections { get; set; }

        #endregion

        [MaxLength(40)]
        public string MaderLog { get; set; }
    }
}
