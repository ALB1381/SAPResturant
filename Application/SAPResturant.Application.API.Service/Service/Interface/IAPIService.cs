using SAPResturant.Application.API.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPResturant.Application.API.Service.Service.Interface
{
    public interface IAPIService
    {
 
        public Task<CashierDashboardDTO> GetCashierDashboardInformationDTO();
        public Task<CreatNewOrderDTO> GetCreateNewOrderFromCashierPageDTO();
        public Task<List<LittleCustomerInformationDTO>> GetCustomerLittleInformationDTOByPhoneNumber(string phoneNumber);
        public Task<int> CreateNewOrderFromCashier(CreateNewOrderFormDTO createNewOrderFormDTO);
     
        public Task<int> CreateNewCustomer(CreateNewCustomerDTO ExDto);
        public Task RemoveInnerOrderFromCashier(int OrderId);

        public Task<List<KitchenDashboardDTO>> GetKitchenDashboardDTOs();
        public Task<KitchenOrderStatusUpdateResult> UpdateKitchenOrderStatus(int orderId, string status);
    }
}
