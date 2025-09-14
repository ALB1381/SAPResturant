using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPResturant.Data.Entities.Owners
{
    public class SubTransaction
    {
        #region Columns
        [Key]
        public int SubTransactionId { get; set; }

        public int SubTransactionPrice { get; set; }

        public DateOnly SubTransactionDate { get; set; }
        public bool IsPayed { get; set; }

        public DateTime? SubTransactionPayed { get; set; }

        public DateTime? SubTransactionPlanedToPay { get; set; }

        [MaxLength(60)]
        public string? ProofOfPaymentIfItNeeds { get; set; }

        [MaxLength(100)]
        public string? Description { get; set; }
        #endregion

        #region Rel
        public int? PayedMethodBuyId { get; set; }
        public int OwnerTransactionId { get; set; }
        [ForeignKey("OwnerTransactionId")]
        public OwnerTransaction OwnerTransaction { get; set; }

        [ForeignKey("PayedMethodBuyId")]
        public TransactionPaymentMethod? TransactionPaymentMethod { get; set; }
        #endregion





    }
}
