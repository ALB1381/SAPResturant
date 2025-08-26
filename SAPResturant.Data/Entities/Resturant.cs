using System.ComponentModel.DataAnnotations;

namespace SAPResturant.Data.Entities
{
    public class Resturant
    {
        // An Owner can have multiple Restaurants and a restaurant can have multiple Sections

        [Key]
        public int ResturantId { get; set; }

        public string ResturantName { get; set; }


        public List<Branch> Branches { get; set; }

        public int OwnerId { get; set; }
    }
}