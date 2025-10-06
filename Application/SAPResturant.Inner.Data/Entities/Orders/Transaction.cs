using SAPResturant.Inner.Data.Entities.Orders.Space;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAPResturant.Inner.Data.Entities.Orders
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }
        public int TransactionSum { get; set; }

        public DateTime TransactionCreateDate { get; set; }
        public DateTime? TransactionPayedTime { get; set; }

        public int OrderId { get; set; }

        [ForeignKey("OrderId")]
        public InnerOrder InnerOrder { get; set; }

        public int PaymentMethodId { get; set; }

        [ForeignKey("PaymentMethodId")]
        public PaymentMethod PaymentMethod { get; set; }
        public int? IncomCardId { get; set; }
        [ForeignKey("IncomCardId")]
        public IncomeCard? IncomeCard { get; set; }
        public int? PoseId { get; set; }
        [ForeignKey("PoseId")]
        public Pose? Pose { get; set; }

        public int? TableReservationId { get; set; }
        [ForeignKey("TableReservationId")]
        public TableReservation? TableReservation { get; set; }
        public bool IsPayed { get; set; }

        [MaxLength(40)]
        public string MaderLog { get; set; }

    }
}
