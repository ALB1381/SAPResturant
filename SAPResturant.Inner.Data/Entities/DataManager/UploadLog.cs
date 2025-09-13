using SAPResturant.Inner.Data.Entities.Orders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
