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
        [Key]
        public int TableId { get; set; }

        public short Capacity { get; set; }

        public short TableNumber { get; set; }
        
        public int BranchId { get; set; }


        [MaxLength(70)]
        public string? Location { get; set; }

        [ForeignKey("BranchId")]
        public Branch Branch { get; set; }
        //public List<Order>? Orders { get; set; }

    }
}
