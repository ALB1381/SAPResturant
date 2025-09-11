using System.ComponentModel.DataAnnotations;

namespace SAPResturant.Inner.Data.Entities.Menus
{
    public class ItemGroup
    {
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

        public List<Item>? Items { get; set; }
    }
}