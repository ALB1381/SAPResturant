using SAPResturant.Data.Entities.Resturants.Menus;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPResturant.Data.Entities.Resturants.Orders
{
    public class SubOnlineOrder
    {
        #region Columns
        [Key]
        public long SubOuterOrderId { get; set; }
        public int Count { get; set; }
        public int? SinglePrice { get; set; }
        public int? SumPrice { get; set; }
        public DateTime MadeDate { get; set; }
        public DateTime CookedTime { get; set; }
        #endregion


        #region Rel
        public long? ItemCaseID { get; set; }
        [ForeignKey("ItemCaseID")]
        public ItemModel? ItemModel { get; set; }

        public long? ExtraOnItemId { get; set; }
        [ForeignKey("ExtraOnItemId")]
        public ExteraItem? ExteraItem { get; set; }

        public long OuterOrderId { get; set; }
        [ForeignKey("OuterOrderId")]
        public OnlineOrder OnlineOrder { get; set; }

        public int BranchId { get; set; }
        [ForeignKey("BranchId")]
        public Branch Branch { get; set; }
        #endregion




        [MaxLength(30)]
        public string OnMadeLog { get; set; }
    }
}
