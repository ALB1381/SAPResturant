using SAPResturant.Inner.Data.Entities.Menus;
using System.ComponentModel.DataAnnotations;

namespace SAPResturant.Inner.Data.Entities.Orders.Discount
{
    public class ItemDiscount
    {
        [Key]
        public int DisocuntId { get; set; }

        [MaxLength(40)]
        public string? Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public short? AvaibleCount { get; set; }
        public short DiscountPercent { get; set; }
        public List<ItemCase> ItemCases { get; set; }

        [MaxLength(40)]
        public string MaderLog { get; set; }
    }
}