using SAPResturant.Data.Entities.Resturants.Orders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPResturant.Data.Entities.Resturants.Menus
{
    public class ExteraItem
    {
        #region Columns
        [Key]
        public long Id { get; set; }
        [MaxLength(50)]
        public string ExteraOnItemTitle { get; set; }
        [MaxLength(50)]
        public string? ExtraOnItemDescription { get; set; }
        public int? Price { get; set; }
        #endregion





        #region Rel
        public int BranchId { get; set; }
        [ForeignKey("BranchId")]
        public Branch Branch { get; set; }
        public int? MenuId { get; set; }
        [ForeignKey("MenuId")]
        public Menu? Menu { get; set; }
        public List<ItemExteraConnection>? ItemExteraConnections { get; set; }
        public List<SubInnerOrder>? SubInnerOrders { get; set; }
        public List<SubOnlineOrder>? SubOnlineOrders { get; set; }
        #endregion


        [MaxLength(30)]
        public string OnMadeLog { get; set; }
    }
}
