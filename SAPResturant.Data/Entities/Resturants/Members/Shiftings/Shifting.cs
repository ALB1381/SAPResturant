using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAPResturant.Data.Entities.Resturants.Members.Shiftings
{
    public class Shifting
    {
        [Key]
        public long ShiftingId { get; set; }
        public DateTime ShiftStart { get; set; }
        public DateTime ShiftEnd { get; set; }
        [MaxLength(300)]
        public string? Review { get; set; }




        public long? MemberId { get; set; }
        [ForeignKey("MemberId")]
        public Memeber? Memeber { get; set; }
        public int BranchId { get; set; }
        [ForeignKey("BranchId")]
        public Branch Branch { get; set; }



        [MaxLength(30)]
        public string OnMadeLog { get; set; }
    }
}
