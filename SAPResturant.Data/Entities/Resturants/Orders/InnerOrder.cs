using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAPResturant.Data.Entities.Resturants.Orders
{
    public class InnerOrder
    {
        #region Columns
        [Key]
        public long InnerOrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public int RawPrice { get; set; }
        public int TaxPrice { get; set; }
        public int SumPrice { get; set; }
        #endregion




        #region Rel
        public int? OrderStatusId { get; set; }
        [ForeignKey("OrderStatusId")]
        public OrderStatus? OrderStatus { get; set; }

        public long? CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer? Customer { get; set; }

        public long? TableId { get; set; }
        [ForeignKey("TableId")]
        public Table? Table { get; set; }

        public long? MemberId { get; set; }
        [ForeignKey("MemberId")]
        public Members.Memeber? Memeber { get; set; }

        public int BranchId { get; set; }
        [ForeignKey("BranchId")]
        public Branch Branch { get; set; }
        public List<Transaction>? Transactions { get; set; }
        public List<SubInnerOrder>? SubInnerOrders { get; set; }
        #endregion



        [MaxLength(30)]
        public string OnMadeLog { get; set; }

    }
}
