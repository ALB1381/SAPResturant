using SAPResturant.Inner.Data.Entities.Menus;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
