using SAPResturant.Data.Entities.Resturants.Members.Shiftings;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPResturant.Data.Entities.Resturants.Members
{
    public class Memeber
    {
        [Key]
        public long MemeberId { get; set; }

        [MaxLength(100)]
        public string MemberFullName { get; set; }

        [MaxLength(100)]
        public string? MemberUserName { get; set; }

        [Required]
        public byte[]? MemberPasswordHash { get; set; }

        [Required]
        public byte[]? MemberPasswordSalt { get; set; }

        public DateTime RegisterDate { get; set; }

        [MaxLength(20)]
        public string? MemberPhoneNumber { get; set; }
        public int? MemberAge { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DeletedTIme { get; set; }

        [MaxLength(300)]
        public string? MemberAddress { get; set; }

        public int MemberRole { get; set; }
        public int BranchId { get; set; }

        [ForeignKey("BranchId")]
        public Branch Branch { get; set; }

        [ForeignKey("MemberRole")]
        public Role Role { get; set; }


        public List<Shifting>? Shiftings { get; set; }

        public List<ArrivalDepartureHour>? ArrivalDepartureHours { get; set; }
    }
}
