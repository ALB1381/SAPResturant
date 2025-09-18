using SAPResturant.Inner.Data.Entities.Orders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPResturant.Inner.Data.Entities.Users
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [MaxLength(20)]
        public string UserName { get; set; }

        [Required]
        public byte[]? UserPasswordHash { get; set; }

        [Required]
        public byte[]? UserPasswordSalt { get; set; }

        [MaxLength(50)]
        public string UserFullName { get; set; }

        [MaxLength(20)]
        public string? CardId { get; set; }

        public DateOnly? BearthDate { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateOnly? EndOfWorking { get; set; }

        [MaxLength(300)]
        public string? Address { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }

        public int RoleId { get; set; }

        [ForeignKey("RoleId")]
        public Role Role { get; set; }

        public List<PlanedShift> PlanedShifts { get; set; }
        public List<Shift> Shifts { get; set; }
        public List<InnerOrder>? InnerOrders { get; set; }

        [MaxLength(40)]
        public string MaderLog { get; set; }
    }
}
