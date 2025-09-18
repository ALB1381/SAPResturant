using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPResturant.Data.Entities.Resturants.Members.Shiftings
{
    public class PlanedShift
    {
        [Key]
        public long PlanedShiftId { get; set; }
        public DateTime ClockIn { get; set; }
        public DateTime? ClockOut { get; set; }




        public long MemberId { get; set; }
        [ForeignKey("MemberId")]
        public Memeber User { get; set; }
        public int BranchId { get; set; }
        [ForeignKey("BranchId")]
        public Branch Branch { get; set; }



        [MaxLength(30)]
        public string OnMadeLog { get; set; }
    }
}
