using System.ComponentModel.DataAnnotations;

namespace SAPResturant.Data.Entities.Owners.Tickets
{
    public class TicketCategory
    {
        [Key]
        public int TicketCategoryId { get; set; }

        [MaxLength(100)]
        public string TicketCategoryText { get; set; }

        public List<Ticket>? Tickets { get; set; }
    }
}