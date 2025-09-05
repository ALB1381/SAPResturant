using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPResturant.Data.Entities.Resturants.Orders
{
    public class SubInnerOrder
    {
        [Key]
        public int SubId { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public int SumPrice { get; set; }
        public int ItemId { get; set; }
        public int? ItemModelId { get; set; }  
        public int? ExteraItemId { get; set; }
        public int InnerOrderId { get; set; }
        public Data.Entities.Resturants.Menus.Item Item { get; set; }
        public Data.Entities.Resturants.Menus.ItemModels? ItemModel { get; set; }
        public Data.Entities.Resturants.Menus.ExteraItem? ExteraItem { get; set; }
        public InnerOrder InnerOrder { get; set; }
    }
}
