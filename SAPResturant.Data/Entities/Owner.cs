using SAPResturant.Data.Entities.Resturants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPResturant.Data.Entities
{
    public class Owner
    {
        [Key]
        public int OwnerId { get; set; }

        [MaxLength(100)]
        [DataType("nvarchar(100)")]
        public string OwnerName { get; set; }

        [MaxLength(20)]
        [DataType("nvarchar(20)")]
        public string? OwnerPhoneNumber { get; set; }
        [MaxLength(100)]
        [DataType("nvarchar(100)")]
        public string? OwnerEmail { get; set; }

        [Required]
        [MaxLength(100)]
        [DataType("nvarchar(100)")]
        public string OwnerUserName { get; set; }

        [Required]
        public byte[] AdminstratorPasswordHash { get; set; }

        [Required]
        public byte[] AdminstratorPasswordSalt { get; set; }

        // An Owner can have multiple Restaurants and a restaurant can have multiple Sections
        public List<Resturant> Resturants { get; set; }
        public bool Ispayed { get; set; }
    }
}
