using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPResturant.Inner.Data.Entities.DataManager
{
    public class DeleteHistory
    {
        [Key]
        public long HistoryId { get; set; }

        public int DeletedRow { get; set; }


        [MaxLength(100)]
        public string TableName { get; set; }
    }
}
