using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAPResturant.Inner.Data.Entities.Users
{
    public class Shift
    {
        [Key]
        public int ShiftId { get; set; }

        public DateTime ClockIn { get; set; }
        public DateTime ClockOut { get; set; }

        [MaxLength(300)]
        public string? Review { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }

        [MaxLength(40)]
        public string MaderLog { get; set; }


    }
}