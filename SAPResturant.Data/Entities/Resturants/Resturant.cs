using SAPResturant.Data.Entities.Owners;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAPResturant.Data.Entities.Resturants
{
    public class Resturant
    {


        [Key]
        public int ResturantId { get; set; }

        [MaxLength(100)]
        public string ResturantName { get; set; }

        [MaxLength(400)]
        public string MainResturantAddress { get; set; }

        [MaxLength(30)]
        public string? ResturantLogo { get; set; }

        public int OwnerId { get; set; }

        #region Rel

        [ForeignKey("OwnerId")]
        public Owner Owner { get; set; }

        public List<Branch>? Branches { get; set; }

        #endregion





        [MaxLength(30)]
        public string OnMadeLog { get; set; }

    }
}