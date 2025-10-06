using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAPResturant.Inner.Data.Entities.Users
{
    public class RolePermissionConnection
    {
        [Key]
        public int ConnectionId { get; set; }

        public int RoleId { get; set; }

        public int PermissionId { get; set; }

        [ForeignKey("RoleId")]
        public Role Role { get; set; }

        [ForeignKey("PermissionId")]
        public Permission Permission { get; set; }

        [MaxLength(40)]
        public string MaderLog { get; set; }
    }
}
