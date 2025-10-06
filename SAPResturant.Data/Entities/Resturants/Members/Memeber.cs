using SAPResturant.Data.Entities.Resturants.Members.Shiftings;
using SAPResturant.Data.Entities.Resturants.Orders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAPResturant.Data.Entities.Resturants.Members
{
    public class Memeber
    {
        #region Columns
        [Key]
        public long MemeberId { get; set; }
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
        public DateTime? EndOfWorking { get; set; }

        [MaxLength(300)]
        public string? Address { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }

        [MaxLength(100)]
        public string Role { get; set; }
        #endregion




        #region Rel
        public int BranchId { get; set; }
        [ForeignKey("BranchId")]
        public Branch Branch { get; set; }
        public List<Shifting>? Shiftings { get; set; }
        public List<PlanedShift>? PlanedShifts { get; set; }
        public List<InnerOrder>? InnerOrders { get; set; }
        #endregion




        [MaxLength(30)]
        public string OnMadeLog { get; set; }
    }
}
