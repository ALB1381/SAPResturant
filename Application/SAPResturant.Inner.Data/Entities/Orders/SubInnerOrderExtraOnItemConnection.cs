using SAPResturant.Inner.Data.Entities.Menus;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAPResturant.Inner.Data.Entities.Orders
{
    public class SubInnerOrderExtraOnItemConnection
    {
        public int SubInnerOrderId { get; set; }
        public int ExtraOnItemId { get; set; }

        [ForeignKey(nameof(SubInnerOrderId))]
        public SubInnerOrder SubInnerOrder { get; set; } = null!;

        [ForeignKey(nameof(ExtraOnItemId))]
        public ExtraOnItem ExtraOnItem { get; set; } = null!;
    }
}
