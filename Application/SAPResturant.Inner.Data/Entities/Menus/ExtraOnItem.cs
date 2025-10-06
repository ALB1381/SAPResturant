using SAPResturant.Inner.Data.Entities.Menus.Connections;
using SAPResturant.Inner.Data.Entities.Orders;
using System.ComponentModel.DataAnnotations;

namespace SAPResturant.Inner.Data.Entities.Menus
{
    public class ExtraOnItem
    {
        [Key]
        public int ExtraOnItemId { get; set; }

        [MaxLength(50)]
        public string ExtraOnItemTitle { get; set; }

        [MaxLength(50)]
        public string? ExtraOnItemDescription { get; set; }

        public int? ExtraOnItemPrice { get; set; }

        public List<ExtraOnItemItemConnection>? ExtraOnItemItemConnections { get; set; }
        public List<SubInnerOrder>? SubInnerOrders { get; set; }
        public List<SubOuterOrder>? SubOuterOrders { get; set; }

        [MaxLength(40)]
        public string MaderLog { get; set; }
    }
}