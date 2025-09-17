using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAPResturant.Inner.Data.Entities.Menus
{
    public class ItemGroup
    {
        #region Columns
        [Key]
        public int ItemGroupId { get; set; }

        [MaxLength(50)]
        public string GroupName { get; set; }

        [MaxLength(16)]
        public string? GroupBgColor { get; set; }

        [MaxLength(16)]
        public string? GroupTextColor { get; set; }

        [MaxLength(16)]
        public string? GroupCardColors { get; set; }
        #endregion



        #region Rel

        public int? ParentId { get; set; }

        [ForeignKey("ParentId")]
        public List<ItemGroup>? ItemParenttGroups { get; set; }

        [InverseProperty("ItemGroup")]
        public List<Item> Items { get; set; }

        [InverseProperty("ItemSubGroup")]
        public List<Item>? SubItems { get; set; }
        #endregion




        [MaxLength(40)]
        public string MaderLog { get; set; }
    }
}