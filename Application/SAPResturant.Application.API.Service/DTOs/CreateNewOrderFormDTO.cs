using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPResturant.Application.API.Service.DTOs
{
    public class CreateNewOrderFormDTO
    {
        public List<SubOrderLittleInformationDTO> SubOrders { get; set; } = new();
        public int? CustomerId { get; set; }
        public CreateNewCustomerDTO? NewCustomer { get; set; }
        public string? CustomerName { get; set; }
        public string? CustomerPhoneNumber { get; set; }
        public string? Description { get; set; }
        public int? TableId { get; set; }
        public int PaymentMethodId { get; set; }
        public string OrderType { get; set; } = string.Empty;
        public string LogFromClient { get; set; } = string.Empty;
        public bool IsMan { get; set; }
    }
    public class SubOrderLittleInformationDTO
    {
        public int ItemCaseId { get; set; }
        public int Count { get; set; }
        public List<int>? ExtraOnItemId { get; set; }
    }
}
