using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAPResturant.Data.Entities.Resturants.Members
{
    public class ArrivalDepartureHour
    {
        [Key]
        public int ArrivalHourId { get; set; }
        public DateTime ArrivalTime { get; set; }
        public DateTime DepartureHour { get; set; }
        public long MemeberId { get; set; }
        public int BranchId { get; set; }

        [ForeignKey("MemeberId")]
        public Memeber Memeber { get; set; }

        [ForeignKey("BranchId")]
        public Branch Branch { get; set; }
    }
}