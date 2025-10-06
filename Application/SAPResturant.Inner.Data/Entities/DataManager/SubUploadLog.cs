using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAPResturant.Inner.Data.Entities.DataManager
{
    public class SubUploadLog
    {
        [Key]
        public long SubUploadLogId { get; set; }
        public DateTime MadeDate { get; set; }
        public bool Uploaded { get; set; }
        public DateTime? UploadedTime { get; set; }
        public string LogScript { get; set; }
        public long LogID { get; set; }

        [ForeignKey("LogID")]
        public UploadLog UploadLog { get; set; }
    }
}