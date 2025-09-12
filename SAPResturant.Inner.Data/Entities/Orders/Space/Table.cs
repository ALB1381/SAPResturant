using SAPResturant.Inner.Data.Entities.Orders.Space.Connection;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace SAPResturant.Inner.Data.Entities.Orders.Space
{
    public class Table
    {
        [Key]
        public int TableId { get; set; }

        [MaxLength(50)]
        public string? TableDescription { get; set; }
        public int TableNumber { get; set; }
        [MaxLength(50)]
        public string? TableName { get; set; }
        public int CountOfSeats { get; set; }

        public int? PriceOfReservation { get; set; }
        public int? PeriodHourOfReservation { get; set; }
      
        public int? ResturantSectionId { get; set; }
        [ForeignKey("ResturantSectionId")]
        public ResturanSection? ResturanSection { get; set; }

        public int? TableStatusId { get; set; }
        [ForeignKey("TableStatusId")]
        public TableStatus? TableStatus { get; set; }

        public List<TableReservationTableConnection>? TableReservationTableConnections { get; set; }




    }
}
