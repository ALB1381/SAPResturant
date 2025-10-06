using System.ComponentModel.DataAnnotations;

namespace SAPResturant.Data.Entities.Resturants
{
    public class CustomerSex
    {
        [Key]
        public int SexId { get; set; }
        [MaxLength(5)]
        public string SexName { get; set; }

        public List<Customer>? Customers { get; set; }





        [MaxLength(30)]
        public string OnMadeLog { get; set; }
    }
}
