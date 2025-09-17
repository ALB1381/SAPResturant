using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPResturant.Data.Entities.Resturants.Members.Shiftings
{
    public class Shifting
    {
        [Key]
        public int ShiftingId { get; set; }
        public int BranchId { get; set; }
        public long MemberId { get; set; }
        public DateTime ShiftStart { get; set; }
        public DateTime ShiftEnd { get; set; }

        [MaxLength(300)]
        public string? Review { get; set; }

        [ForeignKey("MemberId")]
        public Memeber Memeber { get; set; }
        [ForeignKey("BranchId")]
        public Branch Branch { get; set; }
    }
}
