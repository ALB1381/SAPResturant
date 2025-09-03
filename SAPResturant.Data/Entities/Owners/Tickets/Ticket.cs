using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAPResturant.Data.Entities.Owners.Tickets
{
    public class Ticket
    {
        [Key]
        public int TicketID { get; set; }

        [MaxLength(100)]
        public string TicketHeader { get; set; }

        [MaxLength(1000)]
        public string TicketText { get; set; }

        public int TicketModelId { get; set; }

        public int TicketCategoryId { get; set; }

        public DateTime TicketTime { get; set; }

        public bool WasItResponse { get; set; }

        public bool IsActive { get; set; }

        public int? ParentId { get; set; } // Nullable to allow root tickets

        [ForeignKey("ParentId")]
        public List<Ticket> Tickets { get; set; }

        // Navigation properties
        [ForeignKey("TicketModelId")]
        public TicketModel TicketModel { get; set; }

        [ForeignKey("TicketCategoryId")]
        public TicketCategory TicketCategories { get; set; }
    }
}