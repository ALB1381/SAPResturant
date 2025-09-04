using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAPResturant.Data.Entities.Resturants.Menus
{
    public class ItemGroup
    {
        [Key]
        public int GroupId { get; set; }

        [MaxLength(50)]
        public string GroupName { get; set; }

        public int? ParentId { get; set; }

        [ForeignKey("ParentId")]
        public List<ItemGroup>? ItemParenttGroups { get; set; }

        [InverseProperty("ItemGroup")]
        public List<Item> Items { get; set; }

        [InverseProperty("ItemSubGroup")]
        public List<Item>? SubItems { get; set; }

        [MaxLength(50)]
        public string? VisualIdentityColor { get; set; }

        public int MenuId { get; set; }

        [ForeignKey("MenuId")]
        public Menu Menu { get; set; }
    }
}