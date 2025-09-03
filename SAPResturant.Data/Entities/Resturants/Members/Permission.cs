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

        [MaxLength(100)]
        public string PermissionName { get; set; }

    }
}
