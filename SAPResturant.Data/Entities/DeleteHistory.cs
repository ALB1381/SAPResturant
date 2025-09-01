using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPResturant.Data.Entities
{
    public class DeleteHistory
    {
        [Key]
        public int HistoryId { get; set; }

        public int DeletedRow { get; set; }


        [DataType("nvarchar(100)")]
        public string TableName { get; set; }
    }
}
