using System.ComponentModel.DataAnnotations;

namespace SAPResturant.Data.Entities.Owners
{
    public class TransactionPaymentMethod
    {
        [Key]
        public int MethodId { get; set; }

        [MaxLength(50)]
        public string NameOfMethod { get; set; }

        [MaxLength(300)]
        public string? Description { get; set; }

        public List<SubTransaction> SubTransactions { get; set; }
    }
}