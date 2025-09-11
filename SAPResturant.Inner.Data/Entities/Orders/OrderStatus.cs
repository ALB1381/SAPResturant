using System.ComponentModel.DataAnnotations;

namespace SAPResturant.Inner.Data.Entities.Orders
{
    public class OrderStatus
    {
        [Key]
        public int OrderStatusId { get; set; }

        [MaxLength(100)]
        public string? StatusName { get; set; }

        [AllowedValues(1,100)]
        public short Percent { get; set; }

        public List<InnerOrder>? InnerOrders { get; set; }
        public List<OuterOrder>? OuterOrders { get; set; }
    }
}