using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace SAPResturant.Data.Entities.Owners
{
    public class OwnerTransaction
    {
        #region Columns
        [Key]
        public int TransactionId { get; set; }
        public int TransactionPrice { get; set; }
        public DateOnly TransactionDate { get; set; }
        public bool IsPayed { get; set; }
        public DateTime? PayedTiime { get; set; }
        [MaxLength(100)]
        public string? Description { get; set; }
        [MaxLength(60)]
        public string? ProofOfPaymentIfItNeeds { get; set; }
        #endregion

        #region Re
        public int OwnerId { get; set; }
        public int? PayMethodId { get; set; }


        [ForeignKey("OwnerId")]
        public Owner Owner { get; set; }

        public List<SubTransaction> SubTransactions { get; set; }

        [ForeignKey("PayMethodId")]
        public TransactionPaymentMethod? TransactionPaymentMethod { get; set; }
        

        #endregion
      


    }
}
