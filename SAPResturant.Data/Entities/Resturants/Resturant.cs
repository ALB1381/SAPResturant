using SAPResturant.Data.Entities.Owners;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAPResturant.Data.Entities.Resturants
{
    public class Resturant
    {
        // An Owner can have multiple Restaurants and a restaurant can have multiple Sections

        [Key]
        public int ResturantId { get; set; }

        [MaxLength(100)]
        [DataType("nvarchar(100)")]
        public string ResturantName { get; set; }

        [MaxLength(400)]
        [DataType("nvarchar(400)")]
        public string MainResturantAddress { get; set; }
        
        public int OwnerId { get; set; }
        public int CityId { get; set; }

        #region Rel

        [ForeignKey("OwnerId")]
        public Owner Owner { get; set; }

        public List<Branch> Branches { get; set; }

        [ForeignKey("CityId")]
        public City City { get; set; }
        #endregion

    }
}