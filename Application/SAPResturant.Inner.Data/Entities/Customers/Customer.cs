using SAPResturant.Inner.Data.Entities.Orders;
using SAPResturant.Inner.Data.Entities.Orders.Space;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAPResturant.Inner.Data.Entities.Customers
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [MaxLength(100)]
        public string? CustomerName { get; set; }

        [MaxLength(15)]
        public string? CustomerPhone { get; set; }

        [Column(TypeName = "TINYINT")]
        public int? Age { get; set; }

        [Column(TypeName = "nvarchar(800)")]
        [MaxLength(800)]
        public string? Address { get; set; }

        public DateTime FirstShop { get; set; }
        [MaxLength(100)]
        public string? Email { get; set; }

        [MaxLength(24)]
        public string? EmailActiveCode { get; set; }
        public DateTime? EmailActiveSentCodeDate { get; set; }
        public bool IsEmailActivated { get; set; }
        public bool IsPhoneNumberValidated { get; set; }
        [MaxLength(8)]
        public string? PhoneNumberActiveCode { get; set; }
        public DateTime? PhoneNumberActiveSentCodeDate { get; set; }
        public bool IsMan { get; set; }
        public List<InnerOrder>? InnerOrders { get; set; }
        public List<OuterOrder>? OuterOrders { get; set; }
        public List<TableReservation>? TableReservation { get; set; }

        [MaxLength(40)]
        public string MaderLog { get; set; }
    }
}
