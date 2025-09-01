using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
