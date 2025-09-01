using System.ComponentModel.DataAnnotations;

namespace SAPResturant.Data.Entities.Resturants
{
    public class Country
    {
        [Key]
        public int CountryId { get; set; }

        [MaxLength(100)]
        public string CountryName { get; set; }
        public List<City> Cities { get; set; }

    }
}