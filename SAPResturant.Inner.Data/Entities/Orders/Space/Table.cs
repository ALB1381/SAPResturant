using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPResturant.Inner.Data.Entities.Orders.Space
{
    public class Table
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string? TableDescription { get; set; }
        public int TableNumber { get; set; }
        [MaxLength(50)]
        public string? TableName { get; set; }
        public int CountOfSeate { get; set; }


        public int? ResturantSectionId { get; set; }
        [ForeignKey("ResturantSectionId")]
        public ResturanSection? ResturanSection { get; set; }

        public int? TableStatusId { get; set; }
        [ForeignKey("TableStatusId")]
        public TableStatus? TableStatus { get; set; }




    }
}
