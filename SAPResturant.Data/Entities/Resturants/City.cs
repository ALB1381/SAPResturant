using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAPResturant.Data.Entities.Resturants
{
    public class City
    {
        [Key]
        public int CityId { get; set; }

        [MaxLength(100)]
        [DataType("nvarchar(100)")]
        public string CityName { get; set; }

        public int CountryId { get; set; }



        [ForeignKey("CountryId")]
        public Country Country { get; set; }
        public List<Branch> Branches { get; set; }

    }
}