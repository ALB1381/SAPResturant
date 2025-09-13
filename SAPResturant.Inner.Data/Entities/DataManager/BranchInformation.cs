using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPResturant.Inner.Data.Entities.DataManager
{
    public class BranchInformation
    {
        [Key]
        public int ThisBranchInformationId { get; set; } = 1;
        public bool IsBranchEnabledApplication { get; set; }
        [MaxLength(100)]
        public string? BranchName { get; set; }
        [MaxLength(100)]
        public string NameOfResturant { get; set; }

        public int? MainResturantId { get; set; }

        [MaxLength(100)]
        public string? MainResturantName { get; set; }
        public int CityId { get; set; }
        public int CountryId { get; set; }

        [ForeignKey("CityId")]
        public City City { get; set; }

        [ForeignKey("CountryId")]
        public Country Country { get; set; }

        public int? BranchGivenId { get; set; }


    }
}
