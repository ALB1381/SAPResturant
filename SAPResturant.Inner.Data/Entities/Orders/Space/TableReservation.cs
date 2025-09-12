using SAPResturant.Inner.Data.Entities.Customers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAPResturant.Inner.Data.Entities.Orders.Space
{
    public class TableReservation
    {
        [Key]
        public int ResevationId { get; set; }

        public DateTime ReservationTime { get; set; }
        public DateTime? ReservationEnd { get; set; }

        [MaxLength(300)]
        public string? ReservationDescription { get; set; }
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }

        public List<Transaction>? Transactions { get; set; }
        public List<Table> Tables { get; set; }

    }
}