using SAPResturant.Data.Entities.Resturants.Orders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAPResturant.Data.Entities.Resturants
{
    public class TableReservation
    {
        [Key]
        public long ResevationId { get; set; }

        public DateTime ReservationTime { get; set; }
        public DateTime? ReservationEnd { get; set; }

        [MaxLength(300)]
        public string? ReservationDescription { get; set; }
        public long CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }

        public List<Transaction>? Transactions { get; set; }
        public List<TableReservationTableConnection>? TableReservationTableConnections { get; set; }

        public int BranchId { get; set; }
        [ForeignKey("BranchId")]
        public Branch Branch { get; set; }




        [MaxLength(30)]
        public string OnMadeLog { get; set; }

    }
}