using System.ComponentModel.DataAnnotations;

namespace SAPResturant.Data.Entities.Resturants
{
    public class TableStatus
    {
        [Key]
        public int TableStatusId { get; set; }

        [MaxLength(60)]
        public string TableStatusName { get; set; }

        public List<Table>? Tables { get; set; }


        [MaxLength(30)]
        public string OnMadeLog { get; set; }


    }
}