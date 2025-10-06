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
    }
}
