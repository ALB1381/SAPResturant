using System.ComponentModel.DataAnnotations;

namespace SAPResturant.Data.Entities
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
