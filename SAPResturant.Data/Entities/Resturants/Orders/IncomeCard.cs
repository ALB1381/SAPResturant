using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPResturant.Data.Entities.Resturants.Orders
{
    public class IncomeCard
    {
        [Key]
        public int IncomeCardId { get; set; }

        [MaxLength(20)]
        public string CardNumber { get; set; }

        [MaxLength(40)]
        public string CardName { get; set; }

        public List<Transaction> Transactions { get; set; }

        public int BranchId { get; set; }

        [ForeignKey("BranchId")]
        public Branch Branch { get; set; }
    }
}
