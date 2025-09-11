using System.ComponentModel.DataAnnotations;

namespace SAPResturant.Inner.Data.Entities.Users
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }

        [MaxLength(100)]
        public string RoleTitle { get; set; }

        public List<User> Users { get; set; }

        public List<RolePermissionConnection> RolePermissionConnections { get; set; }
    }
}