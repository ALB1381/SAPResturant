using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAPResturant.Data.Entities.Resturants.Menus
{
    public class ItemGroup
    {
        #region Columns
        [Key]
        public long GroupId { get; set; }

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
        public long? ParentId { get; set; }

        public int BranchId { get; set; }
        [ForeignKey("BranchId")]
        public Branch Branch { get; set; }

        public int MenuId { get; set; }
        [ForeignKey("MenuId")]
        public Menu Menu { get; set; }

        [ForeignKey("ParentId")]
        public List<ItemGroup>? ItemParenttGroups { get; set; }

        [InverseProperty("ItemGroup")]
        public List<Item> Items { get; set; }

        [InverseProperty("ItemSubGroup")]
        public List<Item>? SubItems { get; set; }
        #endregion




    }
}