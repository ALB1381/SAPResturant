using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAPResturant.Data.Entities.Resturants
{
    public class Branch
    {
        [Key]
        public int BranchId { get; set; }

        public int ResturantId { get; set; }
        public int SectionId { get; set; }

        [MaxLength(400)]
        [DataType("nvarchar(400)")]
        public string? SectionAddress { get; set; }

        [ForeignKey("ResturantId")]
        public Resturant Resturant { get; set; }
    }
}