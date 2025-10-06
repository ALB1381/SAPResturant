using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAPResturant.Data.Entities.Resturants.Orders
{
    public class Pose
    {
        [Key]
        public int PoseId { get; set; }

        [MaxLength(30)]
        public string PoseName { get; set; }

        public List<Transaction>? Transactions { get; set; }

        public int BranchId { get; set; }
        [ForeignKey("BranchId")]
        public Branch Branch { get; set; }



        [MaxLength(30)]
        public string OnMadeLog { get; set; }
    }
}
