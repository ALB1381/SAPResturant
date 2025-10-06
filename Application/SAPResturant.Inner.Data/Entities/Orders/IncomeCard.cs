using System.ComponentModel.DataAnnotations;

namespace SAPResturant.Inner.Data.Entities.Orders
{
    public class IncomeCard
    {
        [Key]
        public int IncomeCardId { get; set; }

        [MaxLength(40)]
        public string CardNumber { get; set; }

        [MaxLength(40)]
        public string CardName { get; set; }

        public List<Transaction> Transactions { get; set; }

        [MaxLength(40)]
        public string MaderLog { get; set; }

    }
}
