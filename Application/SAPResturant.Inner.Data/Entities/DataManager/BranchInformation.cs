using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAPResturant.Inner.Data.Entities.DataManager
{
    public class BranchInformation
    {
        #region Main Columns
        [Key]
        public int ThisBranchInformationId { get; set; } = 1;
        public int? BranchGivenId { get; set; }
        public bool IsOwnerEnabledApplication { get; set; }

        [MaxLength(100)]
        public string? BranchName { get; set; }

        [MaxLength(400)]
        public string? SectionAddress { get; set; }
        public int? MainBranchId { get; set; }

        [MaxLength(100)]
        public string? MainBranchName { get; set; }

        public string? OwnerPhoneNuber { get; set; }

        public DateTime ActivatedTime { get; set; }
        #endregion

        #region Rel
        public int CityId { get; set; }
        public int CountryId { get; set; }
        public int BranchTypeId { get; set; }

        [ForeignKey("BranchTypeId")]
        public BranchType BranchType { get; set; }

        [ForeignKey("CityId")]
        public City City { get; set; }

        [ForeignKey("CountryId")]
        public Country Country { get; set; }
        #endregion

    }
}
