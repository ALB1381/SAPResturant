using System.ComponentModel.DataAnnotations;

namespace SAPResturant.Inner.Data.Entities.Orders.Space
{
    public class ResturanSection
    {
        [Key]
        public int SectionId { get; set; }

        public int SectionNumber { get; set; }

        [MaxLength(100)]
        public string? SectionDescription { get; set; }

        public List<Table> Tables { get; set; }
    }
}