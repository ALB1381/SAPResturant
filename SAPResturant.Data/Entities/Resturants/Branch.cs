using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAPResturant.Data.Entities.Resturants
{
    public class Branch
    {
        [Key]
        public int BranchId { get; set; }
        public int SectionId { get; set; }

        [MaxLength(400)]
        public string? SectionAddress { get; set; }




        public int CityId { get; set; }
        public int BranchTypeId { get; set; }
        public int ResturantId { get; set; }

        [ForeignKey("BranchTypeId")]
        public BranchType BranchType { get; set; }

        [ForeignKey("ResturantId")]
        public Resturant Resturant { get; set; }
        [ForeignKey("CityId")]
        public City City { get; set; }
    }
}