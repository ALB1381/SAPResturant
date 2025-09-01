using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAPResturant.Data.Entities.Resturants
{
    public class BranchType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BranchTypeId { get; set; }


        [MaxLength(100)]
        [DataType("nvarchar(100)")]
        public string Type { get; set; }

        public List<Branch> Branches { get; set; }
    }
}