using System.ComponentModel.DataAnnotations;

namespace SAPResturant.Data.Entities.Resturants.Orders
{
    public class PaymentMethod
    {
        [Key]
        public int MethodId { get; set; }

        [MaxLength(50)]
        public string TitleOfPaymentMethod { get; set; }

        public bool Free { get; set; }
        public List<Transaction>? Transactions { get; set; }




        [MaxLength(30)]
        public string OnMadeLog { get; set; }
    }
}
