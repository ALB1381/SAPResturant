using System.ComponentModel.DataAnnotations;

namespace SAPResturant.Data.Entities
{
    public class Log
    {
        [Key]
        public long LogId { get; set; }

        [MaxLength(50)]
        public string WhateRole { get; set; }
        public int UserId { get; set; }

        [MaxLength(50)]
        public string Command { get; set; }

        [MaxLength(50)]
        public string WhichTable { get; set; }

        [MaxLength(100)]
        public string Message { get; set; }
    }
}
