using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAPResturant.Data.Entities.Resturants.Menus
{
    public class ItemModels
    {
        [Key]
        public int ItemModelId { get; set; }

        [MaxLength(50)]
        public string ModelName { get; set; }

        public int ItemThisModelPrice { get; set; }

        public int ItemId { get; set; }

        [ForeignKey("ItemId")]
        public Item Item { get; set; }
    }
}