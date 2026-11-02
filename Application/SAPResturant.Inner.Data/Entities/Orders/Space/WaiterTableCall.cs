using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAPResturant.Inner.Data.Entities.Orders.Space
{
    public class WaiterTableCall
    {
        [Key]
        public int WaiterTableCallId { get; set; }

        public int TableId { get; set; }

        [ForeignKey(nameof(TableId))]
        public Table Table { get; set; } = null!;

        public DateTime CreatedAtUtc { get; set; }
        public DateTime? AcceptedAtUtc { get; set; }
        public DateTime? ClosedAtUtc { get; set; }

        [MaxLength(20)]
        public string Status { get; set; } = "Waiting";

        [MaxLength(40)]
        public string MaderLog { get; set; } = "WaitingStaff";
    }
}
