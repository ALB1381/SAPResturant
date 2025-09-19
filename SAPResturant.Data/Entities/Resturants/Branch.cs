using SAPResturant.Data.Entities.Resturants.Members;
using SAPResturant.Data.Entities.Resturants.Members.Shiftings;
using SAPResturant.Data.Entities.Resturants.Menus;
using SAPResturant.Data.Entities.Resturants.Orders;
using SAPResturant.Data.Entities.Warehouse;
using SAPResturant.Data.Entities.Warehouse.Connection;
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
        public int? CountryId { get; set; }

        [ForeignKey("BranchTypeId")]
        public BranchType BranchType { get; set; }

        [ForeignKey("ResturantId")]
        public Resturant Resturant { get; set; }

        [ForeignKey("CityId")]
        public City City { get; set; }

        [ForeignKey("CountryId")]
        public Country? Country { get; set; }

        public List<Memeber>? Memebers { get; set; }
        public List<Shifting>? Shiftings { get; set; }
        public List<Table>? Tables { get; set; }
        public List<Customer>? Customers { get; set; }
        public List<InnerOrder>? InnerOrders { get; set; }
        public List<OnlineOrder>? OnlineOrders { get; set; }
        public List<ItemExteraConnection>? itemExteraConnections { get; set; }
        public List<ItemGroup>? ItemGroups { get; set; }
        public List<ItemDiscount>? ItemDiscounts { get; set; }
        public List<TableReservation>? TableReservations { get; set; }
        public List<TableReservationTableConnection>? TableReservationTableConnections { get; set; }
        public List<ResturanSection>? ResturanSections { get; set; }
        public List<IncomeCard>? IncomeCards { get; set; }
        public List<Pose>? Poses { get; set; }
        public List<SubInnerOrder>? SubInnerOrders { get; set; }
        public List<SubOnlineOrder>? SubOnlineOrders { get; set; }
        public List<PlanedShift>? PlanedShifts { get; set; }
        public List<ItemModelInventoryConnection>? ItemModelInventoryConnections { get; set; }
        public List<Exited>? Exiteds { get; set; }
        public List<Inventory>? Inventories { get; set; }
        public List<ExteraItem>? ExteraItems { get; set; }
        public List<Item>? Items { get; set; }
        public List<Menu>? Menus { get; set; }
        public List<ItemModel>? ItemModels { get; set; }
        public List<Transaction>? Transactions { get; set; }
        public List<Supplied>? Supplieds { get; set; }
        public List<Supplier>? Suppliers { get; set; }
        #endregion



        [MaxLength(30)]
        public string OnMadeLog { get; set; }
    }
}