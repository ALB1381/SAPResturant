using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAPResturant.Data.Entities.Owners
{
    public class OwnerNotification
    {
        #region Columns
        [Key]
        public int NotificationId { get; set; }
        [Required]
        [MaxLength(20)]
        public string NotificationReason { get; set; }
        [Required]
        [MaxLength(200)]
        public string Text { get; set; }
        public DateTime NotificationDate { get; set; }
        public DateTime? SeenDate { get; set; }
        public bool IsRead { get; set; }
        #endregion

        #region Rel
        public int OwnerId { get; set; }
        [ForeignKey("OwnerId")]
        public Owner Owner { get; set; }

        #endregion

        [MaxLength(30)]
        public string OnMadeLog { get; set; }
    }
}