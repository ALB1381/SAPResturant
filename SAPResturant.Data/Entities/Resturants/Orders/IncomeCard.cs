using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAPResturant.Data.Entities.Resturants.Orders
{
    public class IncomeCard
    {
        [Key]
        public int IncomeCardId { get; set; }

        [MaxLength(40)]
        public string CardNumber { get; set; }

        [MaxLength(40)]
        public string CardInfo { get; set; }



        public List<Transaction> Transactions { get; set; }
        public int BranchId { get; set; }
        [ForeignKey("BranchId")]
        public Branch Branch { get; set; }




        [MaxLength(30)]
        public string OnMadeLog { get; set; }
    }
}
