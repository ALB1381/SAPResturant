using SAPResturant.Inner.Data.Entities.Customers;
using SAPResturant.Inner.Data.Entities.Orders.Space;
using SAPResturant.Inner.Data.Entities.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPResturant.Inner.Data.Entities.Orders
{
    public class InnerOrder
    {
        [Key]
        public int InnerOrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public int RawPrice { get; set; }
        public int TaxPrice { get; set; }
        public int SumPrice { get; set; }
        public int OrderStatusId { get; set; }


        [ForeignKey("OrderStatusId")]
        public OrderStatus OrderStatus { get; set; }

        public int? CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer? Customer { get; set; }

        public int? TableId { get; set; }
        [ForeignKey("TableId")]
        public Table? Table { get; set; }

        public int? UserId { get; set; }
        [ForeignKey("UserId")]
        public User? User { get; set; }

        public List<Transaction>? Transactions { get; set; }
        public List<SubInnerOrder>? SubInnerOrders { get; set; }

    }
}
