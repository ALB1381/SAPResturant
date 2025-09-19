using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPResturant.Data.Entities.Resturants
{
    public class ResturanSection
    {
        [Key]
        public long SectionId { get; set; }

        public int SectionNumber { get; set; }

        [MaxLength(100)]
        public string? SectionDescription { get; set; }

        public List<Table>? Tables { get; set; }

        public int BranchId { get; set; }
        [ForeignKey("BranchId")]
        public Branch Branch { get; set; }




        [MaxLength(30)]
        public string OnMadeLog { get; set; }
    }
}
