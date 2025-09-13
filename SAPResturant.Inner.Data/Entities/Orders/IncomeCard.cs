using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPResturant.Inner.Data.Entities.Orders
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

        [MaxLength(40)]
        public string MaderLog { get; set; }

    }
}
