using System.ComponentModel.DataAnnotations;

namespace SAPResturant.Inner.Data.Entities.Users
{
    public class Permission
    {
        [Key]
        public int PermissionId { get; set; }

        [MaxLength(20)]
        public string PermissionTitle { get; set; }

        public List<RolePermissionConnection> RolePermissionConnections { get; set; }

        [MaxLength(40)]
        public string MaderLog { get; set; }
    }
}
