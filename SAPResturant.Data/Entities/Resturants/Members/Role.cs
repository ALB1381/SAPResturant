using System.ComponentModel.DataAnnotations;
using System.Runtime;

namespace SAPResturant.Data.Entities.Resturants.Members
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }

        [MaxLength(100)]
        public string RoleName { get; set; }
    }
}