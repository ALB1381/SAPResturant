using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAPResturant.Inner.Data.Entities.DataManager
{
    public class BranchType
    {
        [Key]
        public int TypeId { get; set; }

        [MaxLength(40)]
        public string TypeTitle { get; set; }

        public int? BranchInformationId { get; set; }
        public int CountryId { get; set; }

        [ForeignKey("BranchInformationId")]
        public BranchInformation? BranchInformation { get; set; }

        [ForeignKey("CountryId")]
        public Country Country { get; set; }
    }
}