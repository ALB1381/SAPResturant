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
        [Key]
        public int OnlineOrderId { get; set; }
        public bool IsPayed { get; set; }
        public int OrderSum { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }
        public DateTime OrderDate { get; set; }
        public int? DeliveryPrice { get; set; }
        public int Tax { get; set; }
        public int RawPrice { get; set; }

        [MaxLength(500)]
        public string DeliveryAddress { get; set; }

        public int CustomerId { get; set; }
        public int BranchId { get; set; }
   

        [ForeignKey("BranchId")]
        public Branch Branch { get; set; }

        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
    }
}
