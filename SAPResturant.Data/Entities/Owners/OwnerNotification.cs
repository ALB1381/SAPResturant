using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAPResturant.Data.Entities.Owners
{
    public class OwnerNotification
    {
        [Key]
        public int NotidicationId { get; set; }

        [Required]
        [MaxLength(20)]
        public string NotificationReason { get; set; }

        [Required]
        [MaxLength(300)]
        public string Text { get; set; }

        public DateTime NotificationDate { get; set; }

        public int OwnerId { get; set; }

        [ForeignKey("OwnerId")]
        public Owner Owner { get; set; }
    }
}