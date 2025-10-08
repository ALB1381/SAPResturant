using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPResturant.Application.API.Service.DTOs
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
