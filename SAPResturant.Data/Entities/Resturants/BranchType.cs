using System.ComponentModel.DataAnnotations;

namespace SAPResturant.Data.Entities.Resturants
{
    public class BranchType
    {
        [Key]
        public int BranchTypeId { get; set; }


        [MaxLength(100)]
        public string Type { get; set; }

        public List<Branch> Branches { get; set; }




        [MaxLength(30)]
        public string OnMadeLog { get; set; }
    }
}