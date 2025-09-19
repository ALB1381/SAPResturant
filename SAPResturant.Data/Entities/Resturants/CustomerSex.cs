using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
