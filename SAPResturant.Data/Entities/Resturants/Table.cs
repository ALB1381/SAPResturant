using SAPResturant.Data.Entities.Resturants.Orders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPResturant.Data.Entities.Resturants
{
    public class Table
    {
        #region Columns
        [Key]
        public long TableId { get; set; }
        [MaxLength(50)]
        public string? TableDescription { get; set; }
        public int TableNumber { get; set; }
        [MaxLength(50)]
        public string? TableName { get; set; }
        public int CountOfSeats { get; set; }
        public int? PriceOfReservation { get; set; }
        public int? PeriodHourOfReservation { get; set; }
        #endregion





        #region Rel
        public int BranchId { get; set; }
        [ForeignKey("BranchId")]
        public Branch Branch { get; set; }
        public long? ResturantSectionId { get; set; }
        [ForeignKey("ResturantSectionId")]
        public ResturanSection? ResturanSection { get; set; }
        public int? TableStatusId { get; set; }
        [ForeignKey("TableStatusId")]
        public TableStatus? TableStatus { get; set; }
        public long? InnerOrderId { get; set; }
        [ForeignKey("InnerOrderId")]
        public InnerOrder? InnerOrder { get; set; }
        public List<TableReservationTableConnection>? TableReservationTableConnections { get; set; }
        #endregion







        [MaxLength(30)]
        public string OnMadeLog { get; set; }

    }
}
