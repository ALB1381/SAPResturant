using SAPResturant.Data.Entities.Resturants.Members;
using SAPResturant.Data.Entities.Resturants.Members.Shiftings;
using SAPResturant.Data.Entities.Resturants.Orders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAPResturant.Data.Entities.Resturants
{
    public class Branch
    {
        [Key]
        public int BranchId { get; set; }
        public int SectionId { get; set; }

        [MaxLength(400)]
        public string? SectionAddress { get; set; }

        //Each Resturant have many tables however we dosent need a table to keping tables
        //but we need it to submit it in Orders and this the probelm
  
        public int CityId { get; set; }
        public int BranchTypeId { get; set; }
        public int ResturantId { get; set; }

        #region Rel
        [ForeignKey("BranchTypeId")]
        public BranchType BranchType { get; set; }

        [ForeignKey("ResturantId")]
        public Resturant Resturant { get; set; }

        [ForeignKey("CityId")]
        public City City { get; set; }

        public List<Memeber>? Memebers { get; set; }
        public List<Shifting>? Shiftings { get; set; }
        public List<ArrivalDepartureHour>? ArrivalDepartureHours { get; set; }
        public List<Table> Tables { get; set; }
        public List<Customer> Customers { get; set; }
        public List<InnerOrder> InnerOrders { get; set; }
        public List<OnlineOrder> OnlineOrders { get; set; }

        #endregion

    }
}