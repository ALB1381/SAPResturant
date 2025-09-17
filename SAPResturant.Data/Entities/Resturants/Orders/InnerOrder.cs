using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPResturant.Data.Entities.Resturants.Orders
{
    public class InnerOrder
    {
        [Key]
        public int InnerOrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public int RawPrice { get; set; }
        public int TaxPrice { get; set; }
        public int SumPrice { get; set; }

        public int? OrderStatusId { get; set; }
        [ForeignKey("OrderStatusId")]
        public OrderStatus? OrderStatus { get; set; }

        public int? CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer? Customer { get; set; }

        public int? TableId { get; set; }
        [ForeignKey("TableId")]
        public Table? Table { get; set; }

        public long? MembeId { get; set; }

        [ForeignKey("MembeId")]
        public Members.Memeber? Memeber { get; set; }

        public List<Transaction>? Transactions { get; set; }
        public List<SubInnerOrder>? SubInnerOrders { get; set; }
        public int BranchId { get; set; }
        [ForeignKey("BranchId")]
        public Branch Branch { get; set; }

    }
}
