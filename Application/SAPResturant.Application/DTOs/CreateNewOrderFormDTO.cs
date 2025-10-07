using System.Security.Principal;

namespace SAPResturant.Application.DTOs
{
    public class CreateNewOrderFormDTO
    {
        public List<SubOrderLittleInformationDTO> SubOrders { get; set; }
        public int? CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public string? CustomerPhoneNumber { get; set; }
        public string? Description { get; set; }
    }
    public class SubOrderLittleInformationDTO
    {
        public int ItemCaseId { get; set; }
        public int Count { get; set; }
        public int? ExtraOnItemId { get; set; }
    }
}
