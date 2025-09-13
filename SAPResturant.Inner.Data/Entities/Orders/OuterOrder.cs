using SAPResturant.Inner.Data.Entities.Customers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPResturant.Inner.Data.Entities.Orders
{
    public class OuterOrder
    {
        [Key]
        public int OuterOrderId { get; set; }
        public DateTime OrderDate { get; set; }

        public int RawPrice { get; set; }
        public int TaxPrice { get; set; }
        public int SumPrice { get; set; }
        public int DeliveryPrice { get; set; }
        public int OrderStatusId { get; set; }

        [MaxLength(800)]
        public string DeliveredAddress { get; set; }

        public bool IsSnap { get; set; }

        [ForeignKey("OrderStatusId")]
        public OrderStatus OrderStatus { get; set; }
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
        public List<SubOuterOrder>? SubOuterOrders { get; set; }

        [MaxLength(40)]
        public string MaderLog { get; set; }
    }
}