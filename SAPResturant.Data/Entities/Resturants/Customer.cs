using SAPResturant.Data.Entities.Resturants.Orders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAPResturant.Data.Entities.Resturants
{
    public class Customer
    {

        #region Columns
        [Key]
        public long CustomerId { get; set; }
        public int InnerCustomerId { get; set; }
        [MaxLength(100)]
        public string? CustomerName { get; set; }
        [MaxLength(15)]
        public string? CustomerPhone { get; set; }
        [Column(TypeName = "TINYINT")]
        public int? Age { get; set; }
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
        #endregion



        #region Rel
        public int? SexId { get; set; }
        public int? BranchId { get; set; }
        [ForeignKey("BranchId")]
        public Branch? Branch { get; set; }
        [ForeignKey("SexId")]
        public CustomerSex? CustomerSex { get; set; }
        public List<InnerOrder>? InnerOrders { get; set; }
        public List<OnlineOrder>? OnlineOrders { get; set; }
        public List<TableReservation>? TableReservation { get; set; }
        #endregion




        [MaxLength(30)]
        public string OnMadeLog { get; set; }

    }
}
