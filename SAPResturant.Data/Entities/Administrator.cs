using System.ComponentModel.DataAnnotations;

namespace SAPResturant.Data.Entities
{
    public class Administrator
    {
        [Key]
        public int AdminstratorId { get; set; }

        [Required]
        [MaxLength(100)]
        public string AdminstratorUserName { get; set; }

        [Required]
        public byte[] AdminstratorPasswordHash { get; set; }

        [Required]
        public byte[] AdminstratorPasswordSalt { get; set; }
    }
}
