using SAPResturant.Data.Entities.Resturants.Members;
using SAPResturant.Data.Entities.Resturants.Members.Shiftings;
using SAPResturant.Data.Entities.Resturants.Menus;
using SAPResturant.Data.Entities.Resturants.Orders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAPResturant.Data.Entities.Resturants
{
    public class Branch
    {
        #region Columns
        [Key]
        public int BranchId { get; set; }
        [MaxLength(400)]
        public string? BranchAddress { get; set; }
        public Boolean IsBranchEnabledApplication { get; set; }

        [MaxLength(100)]
        public string BranchName { get; set; }
        #endregion

        #region Rel
        public int CityId { get; set; }
        public int BranchTypeId { get; set; }
        public int ResturantId { get; set; }
        public int CountryId { get; set; }

        [ForeignKey("BranchTypeId")]
        public BranchType BranchType { get; set; }

        [ForeignKey("ResturantId")]
        public Resturant Resturant { get; set; }

        [ForeignKey("CityId")]
        public City City { get; set; }

        [ForeignKey("CountryId")]
        public Country Country { get; set; }

        public List<Memeber>? Memebers { get; set; }
        public List<Shifting>? Shiftings { get; set; }
        public List<ArrivalDepartureHour>? ArrivalDepartureHours { get; set; }
        public List<Table> Tables { get; set; }
        public List<Customer> Customers { get; set; }
        public List<InnerOrder> InnerOrders { get; set; }
        public List<OnlineOrder> OnlineOrders { get; set; }
        public List<ItemExteraConnection> itemExteraConnections { get; set; }
        #endregion

    }
}