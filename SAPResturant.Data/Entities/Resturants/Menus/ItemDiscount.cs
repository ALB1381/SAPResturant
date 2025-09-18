using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAPResturant.Data.Entities.Resturants.Menus
{
    public class ItemDiscount
    {

        #region Columns
        [Key]
        public int DisocuntId { get; set; }

        [MaxLength(40)]
        public string? Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public short? AvaibleCount { get; set; }
        public short DiscountPercent { get; set; }
        #endregion


        #region Rel
        public List<ItemModel>? ItemModels { get; set; }

        public int? MenuId { get; set; }
        [ForeignKey("MenuId")]
        public Menu? Menu { get; set; }

        public int? BranchId { get; set; }
        [ForeignKey("BranchId")]
        public Branch? Branch { get; set; }
        #endregion



        [MaxLength(30)]
        public string OnMadeLog { get; set; }
    }
}