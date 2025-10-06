using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAPResturant.Data.Entities.Resturants.Menus
{
    public class Menu
    {
        [Key]
        public int MenuId { get; set; }

        public int BranchId { get; set; }

        public List<ItemGroup>? ItemGroups { get; set; }
        public List<Item>? Items { get; set; }

        [ForeignKey("BranchId")]
        public Branch Branch { get; set; }

        public List<ItemDiscount>? ItemDiscounts { get; set; }
        public List<ExteraItem>? ExteraItems { get; set; }
        public List<ItemModel>? ItemModels { get; set; }



        [MaxLength(30)]
        public string OnMadeLog { get; set; }
    }
}
