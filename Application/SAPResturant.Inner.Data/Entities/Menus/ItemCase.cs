using SAPResturant.Inner.Data.Entities.Orders;
using SAPResturant.Inner.Data.Entities.Orders.Discount;
using SAPResturant.Inner.Data.Entities.Warehouse.Connection;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAPResturant.Inner.Data.Entities.Menus
{
    public class ItemCase
    {
        #region Columns
        [Key]
        public int ItemCaseId { get; set; }

        [MaxLength(50)]
        public string CaseTitle { get; set; }
        public int CasePrice { get; set; }
        public int? AvaibleCount { get; set; }
        #endregion


        #region Rel
        public int ItemId { get; set; }
        [ForeignKey("ItemId")]
        public Item Item { get; set; }

        public int? DsicountId { get; set; }
        [ForeignKey("DsicountId")]
        public ItemDiscount? ItemDiscount { get; set; }

        public List<ItemCaseInventoryConnection>? ItemCaseInventoryConnections { get; set; }
        public List<SubInnerOrder>? SubInnerOrders { get; set; }
        public List<SubOuterOrder>? SubOuterOrders { get; set; }
        #endregion


        [MaxLength(40)]
        public string MaderLog { get; set; }
    }
}