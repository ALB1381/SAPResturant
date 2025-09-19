using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPResturant.Data.Entities.Resturants.Orders
{
    public class OnlineOrder
    {
        #region Columns

        [Key]
        public long OuterOrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public int RawPrice { get; set; }
        public int TaxPrice { get; set; }
        public int SumPrice { get; set; }
        public int DeliveryPrice { get; set; }
        public bool IsSnap { get; set; }
        [MaxLength(800)]
        public string DeliveredAddress { get; set; }

        #endregion


        #region Rel
        public int OrderStatusId { get; set; }
        [ForeignKey("OrderStatusId")]
        public OrderStatus OrderStatus { get; set; }
        public long CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
        public List<SubOnlineOrder>? SubOnlineOrders { get; set; }
        #endregion

        public int BranchId { get; set; }
        [ForeignKey("BranchId")]
        public Branch Branch { get; set; }



        [MaxLength(30)]
        public string OnMadeLog { get; set; }
    }
}
