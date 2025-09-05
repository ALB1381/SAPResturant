using SAPResturant.Data.Entities.Resturants.Orders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPResturant.Data.Entities.Resturants
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

        public bool IsPhoneNumberValidated { get; set; }

        [Column(TypeName = "nvarchar(8)")]
        public string? PhoneNumberActiveCode { get; set; }
        public DateTime? SentCode { get; set; }
        public int? SexId { get; set; }
        public int BranchId { get; set; }

        [ForeignKey("BranchId")]
        public Branch Branch { get; set; }

        [ForeignKey("SexId")]
        public CustomerSex? CustomerSex { get; set; }

        public List<InnerOrder>? InnerOrders { get; set; }

        public List<OnlineOrder>? OnlineOrders { get; set; }
    }
}
