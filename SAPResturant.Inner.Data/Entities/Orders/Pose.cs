using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPResturant.Inner.Data.Entities.Orders
{
    public class Pose
    {
        [Key]
        public int PoseId { get; set; }

        [MaxLength(30)]
        public string PoseName { get; set; }

        public List<Transaction>? Transactions { get; set; }
    }
}
