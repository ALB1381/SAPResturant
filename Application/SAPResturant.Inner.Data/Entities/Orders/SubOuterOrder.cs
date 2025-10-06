using SAPResturant.Inner.Data.Entities.Menus;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAPResturant.Inner.Data.Entities.Orders
{
    public class SubOuterOrder
    {
        [Key]
        public int SubOuterOrderId { get; set; }

        public int Count { get; set; }
        public int? SinglePrice { get; set; }
        public int? SumPrice { get; set; }
        public DateTime MadeDate { get; set; }

        public DateTime CookedTime { get; set; }

        public int? ItemCaseID { get; set; }
        [ForeignKey("ItemCaseID")]
        public ItemCase? ItemCase { get; set; }

        public int? ExtraOnItemId { get; set; }
        [ForeignKey("ExtraOnItemId")]
        public ExtraOnItem? ExtraOnItem { get; set; }

        public int OuterOrderId { get; set; }
        [ForeignKey("OuterOrderId")]
        public OuterOrder OuterOrder { get; set; }

        [MaxLength(40)]
        public string MaderLog { get; set; }
    }
}
