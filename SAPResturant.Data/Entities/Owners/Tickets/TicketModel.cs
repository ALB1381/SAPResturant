using System.ComponentModel.DataAnnotations;

namespace SAPResturant.Data.Entities.Owners.Tickets
{
    public class TicketModel
    {
        [Key]
        public int TicketModelId { get; set; }

        [MaxLength(100)]
        public string TicketModelText { get; set; }

        public List<Ticket>? Tickets { get; set; }
    }
}