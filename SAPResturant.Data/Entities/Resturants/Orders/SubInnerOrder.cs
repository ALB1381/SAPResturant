using SAPResturant.Data.Entities.Resturants.Menus;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAPResturant.Data.Entities.Resturants.Orders
{
    public class SubInnerOrder
    {
        #region Columns
        [Key]
        public long SubInnerOrderId { get; set; }
        public int Count { get; set; }
        public int? SinglePrice { get; set; }
        public int? SumPrice { get; set; }
        public DateTime MadeDate { get; set; }
        public DateTime CookedTime { get; set; }
        public DateTime DeliveredTime { get; set; }
        #endregion


        #region Rel
        public long? ItemModelId { get; set; }
        [ForeignKey("ItemModelId")]
        public ItemModel? ItemModel { get; set; }

        public long? ExtraOnItemId { get; set; }
        [ForeignKey("ExtraOnItemId")]
        public ExteraItem? ExteraItem { get; set; }

        public long InnerOrderId { get; set; }
        [ForeignKey("InnerOrderId")]
        public InnerOrder InnerOrder { get; set; }

        public int BranchId { get; set; }
        [ForeignKey("BranchId")]
        public Branch Branch { get; set; }
        #endregion



        [MaxLength(30)]
        public string OnMadeLog { get; set; }

    }
}
