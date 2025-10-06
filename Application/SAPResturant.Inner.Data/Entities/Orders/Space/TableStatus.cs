using System.ComponentModel.DataAnnotations;

namespace SAPResturant.Inner.Data.Entities.Orders.Space
{
    public class TableStatus
    {
        [Key]
        public int TableStatusId { get; set; }

        [MaxLength(60)]
        public string TableStatusName { get; set; }

        public List<Table> Tables { get; set; }

        [MaxLength(40)]
        public string MaderLog { get; set; }
    }
}