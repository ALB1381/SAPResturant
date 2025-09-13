using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPResturant.Inner.Data.Entities.Orders
{
    public class PaymentMethod
    {
        [Key]
        public int MethodId { get; set; }

        [MaxLength(50)]
        public string TitleOfPaymentMethod { get; set; }

        public bool Free { get; set; }
        public List<Transaction>? Transactions { get; set; }

        [MaxLength(40)]
        public string MaderLog { get; set; }
    }
}
