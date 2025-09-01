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
        [Key]
        public int TransactionId { get; set; }

        public int TransactionPrice { get; set; }

        public DateOnly TransactionDate { get; set; }

        public bool IsPayed { get; set; }


        [MaxLength(100)]
        public string? Description { get; set; }

        public int OwnerId { get; set; }

        [ForeignKey("OwnerId")]
        public Owner Owner { get; set; }

        public List<SubTransaction> SubTransactions { get; set; }
    }
}
