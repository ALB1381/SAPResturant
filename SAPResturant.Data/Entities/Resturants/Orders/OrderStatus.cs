using System.ComponentModel.DataAnnotations;

namespace SAPResturant.Data.Entities.Resturants.Orders
{
    public class OrderStatus
    {
        [Key]
        public int OrderStatusId { get; set; }

        [MaxLength(100)]
        public string? StatusName { get; set; }

        [AllowedValues(1, 100)]
        public short Percent { get; set; }

        public List<InnerOrder>? InnerOrders { get; set; }
        public List<OnlineOrder>? OuterOrders { get; set; }


        [MaxLength(30)]
        public string OnMadeLog { get; set; }
    }
}