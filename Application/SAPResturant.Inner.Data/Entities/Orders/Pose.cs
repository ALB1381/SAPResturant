using System.ComponentModel.DataAnnotations;

namespace SAPResturant.Inner.Data.Entities.Orders
{
    public class Pose
    {
        [Key]
        public int PoseId { get; set; }

        [MaxLength(30)]
        public string PoseName { get; set; }

        public List<Transaction>? Transactions { get; set; }

        [MaxLength(40)]
        public string MaderLog { get; set; }
    }
}
