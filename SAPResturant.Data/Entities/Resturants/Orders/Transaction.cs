using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPResturant.Data.Entities.Resturants.Orders
{
    public class Transaction
    {
        #region Columns
        [Key]
        public long TransactionId { get; set; }
        public int TransactionSum { get; set; }
        public DateTime TransactionCreateDate { get; set; }
        public DateTime? TransactionPayedTime { get; set; }
        public bool IsPayed { get; set; }
        #endregion


        #region Rel
        public long? OrderId { get; set; }

        [ForeignKey("OrderId")]
        public InnerOrder? InnerOrder { get; set; }
        public int PaymentMethodId { get; set; }
        [ForeignKey("PaymentMethodId")]
        public PaymentMethod PaymentMethod { get; set; }
        public int? IncomCardId { get; set; }
        [ForeignKey("IncomCardId")]
        public IncomeCard? IncomeCard { get; set; }
        public int? PoseId { get; set; }
        [ForeignKey("PoseId")]
        public Pose? Pose { get; set; }
        public long? TableReservationId { get; set; }
        [ForeignKey("TableReservationId")]
        public TableReservation? TableReservation { get; set; }
        public int BranchId { get; set; }
        [ForeignKey("BranchId")]
        public Branch Branch { get; set; }
        #endregion



        [MaxLength(30)]
        public string OnMadeLog { get; set; }
    }
}
