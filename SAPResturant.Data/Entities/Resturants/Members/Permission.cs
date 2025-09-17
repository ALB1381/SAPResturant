using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPResturant.Data.Entities.Resturants.Members
{
    public class Permission
    {
        [Key]
        public int PermissionId { get; set; }


        [MaxLength(20)]
        public string PermissionTitle { get; set; }

        public List<RolePermissionConnection> RolePermissionConnections { get; set; }
    }
}
