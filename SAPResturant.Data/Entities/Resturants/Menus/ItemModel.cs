using SAPResturant.Data.Entities.Resturants.Orders;
using SAPResturant.Data.Entities.Warehouse.Connection;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAPResturant.Data.Entities.Resturants.Menus
{
    public class ItemModel
    {
        #region Columns
        [Key]
        public int ItemModelId { get; set; }
        [MaxLength(50)]
        public string ModelName { get; set; }
        public int ItemThisModelPrice { get; set; }
        public int? AvaibleCount { get; set; }
        #endregion



        #region Rel
        public int ItemId { get; set; }
        [ForeignKey("ItemId")]
        public Item Item { get; set; }
        public int? DsicountId { get; set; }
        [ForeignKey("DsicountId")]
        public ItemDiscount? ItemDiscount { get; set; }
        public int? BranchId { get; set; }
        [ForeignKey("BranchId")]
        public Branch? Branch { get; set; }

        public List<ItemModelInventoryConnection>? ItemModelInventoryConnections { get; set; }
        public List<SubInnerOrder>? SubInnerOrders { get; set; }
        public List<SubOnlineOrder>? SubOnlineOrders { get; set; }
        #endregion




    }
}