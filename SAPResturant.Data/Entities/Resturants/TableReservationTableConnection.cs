using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAPResturant.Data.Entities.Resturants
{
    public class TableReservationTableConnection
    {
        [Key]
        public int ConnectionId { get; set; }

        public long? TableReservationId { get; set; }

        public long? TableId { get; set; }

        [ForeignKey("TableReservationId")]
        public TableReservation TableReservation { get; set; }

        [ForeignKey("TableId")]
        public Table Table { get; set; }

        public int BranchId { get; set; }
        [ForeignKey("BranchId")]
        public Branch Branch { get; set; }





        [MaxLength(30)]
        public string OnMadeLog { get; set; }

    }
}
