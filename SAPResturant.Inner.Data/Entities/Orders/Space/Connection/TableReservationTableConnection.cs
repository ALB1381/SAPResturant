using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPResturant.Inner.Data.Entities.Orders.Space.Connection
{
    public class TableReservationTableConnection
    {
        [Key]
        public int ConnectionId { get; set; }

        public int TableReservationId { get; set; }

        public int TableId { get; set; }

        [ForeignKey("TableReservationId")]
        public TableReservation TableReservation { get; set; }

        [ForeignKey("TableId")]
        public Table Table { get; set; }
    }
}
