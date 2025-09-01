using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPResturant.Data.Entities
{
    public class Administrator
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AdminstratorId { get; set; }

        [Required]
        [MaxLength(100)]
        [DataType("nvarchar(100)")]
        public string AdminstratorUserName { get; set; }

        [Required]
        public byte[] AdminstratorPasswordHash { get; set; }

        [Required]
        public byte[] AdminstratorPasswordSalt { get; set; }
    }
}
