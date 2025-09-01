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
        [Key]
        public int SubTransactionId { get; set; }

        public int SubTransactionPrice { get; set; }
        
        public DateOnly SubTransactionDate { get; set; }
        public bool IsPayed { get; set; }

        public int OwnerTransactionId { get; set; }

        [MaxLength(100)]
        public string? Description { get; set; } 


        [ForeignKey("OwnerTransactionId")]
        public OwnerTransaction OwnerTransaction { get; set; }
    }
}
