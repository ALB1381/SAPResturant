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
        public int LogId { get; set; }

        [DataType("nvarchar(50)")]
        public string WhateRole { get; set; }
        public int UserId { get; set; }

        [DataType("nvarchar(50)")]
        public string Command { get; set; }

        [DataType("nvarchar(50)")]
        public string WhichTable { get; set; }

        [DataType("nvarchar(100)")]
        public string Message { get; set; }
    }
}
