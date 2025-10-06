using System.ComponentModel.DataAnnotations;

namespace SAPResturant.Inner.Data.Entities.DataManager
{
    public class UploadLog
    {
        [Key]
        public long LogId { get; set; }
        public DateTime MadeDate { get; set; }
        public DateTime? StartToSent { get; set; }
        public DateTime? DoneToSent { get; set; }
        public bool Sent { get; set; }

        [MaxLength(100)]
        public string LogName { get; set; }

        public List<SubUploadLog>? SubUploadLogs { get; set; }

    }
}
