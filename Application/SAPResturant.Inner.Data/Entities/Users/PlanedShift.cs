using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAPResturant.Inner.Data.Entities.Users
{
    public class PlanedShift
    {
        [Key]
        public int PlanedShiftId { get; set; }
        public DateTime ClockIn { get; set; }
        public DateTime? ClockOut { get; set; }



        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        [MaxLength(40)]
        public string MaderLog { get; set; }
    }
}
