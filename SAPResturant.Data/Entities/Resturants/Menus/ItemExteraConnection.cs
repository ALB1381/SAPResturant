using Microsoft.EntityFrameworkCore.Infrastructure;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.AccessControl;

namespace SAPResturant.Data.Entities.Resturants.Menus
{
    public class ItemExteraConnection
    {
        [Key]
        public int IECId { get; set; }

        public int ItemId { get; set; }

        public int ExteraItemId { get; set; }

        [ForeignKey("ItemId")]
        public Item Item { get; set; }
        [ForeignKey("ExteraItemId")]
        public ExteraItem ExteraItem { get; set; }


    }
}