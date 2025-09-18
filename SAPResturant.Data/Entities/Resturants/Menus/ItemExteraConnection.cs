using Microsoft.EntityFrameworkCore.Infrastructure;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.AccessControl;

namespace SAPResturant.Data.Entities.Resturants.Menus
{
    public class ItemExteraConnection
    {
        [Key]
        public long IECId { get; set; }

        public long ItemId { get; set; }
        [ForeignKey("ItemId")]
        public Item Item { get; set; }
        public long ExteraItemId { get; set; }
        [ForeignKey("ExteraItemId")]
        public ExteraItem ExteraItem { get; set; }
        public int BranchId { get; set; }
        [ForeignKey("BranchId")]
        public Branch Branch { get; set; }



        [MaxLength(30)]
        public string OnMadeLog { get; set; }
    }
}