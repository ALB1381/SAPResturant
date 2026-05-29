using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPResturant.Application.API.Service.DTOs
{
    public class CreateNewCustomerDTO
    {
        public string? CustomerName { get; set; }

        public string? CustomerPhoneNumber { get; set; }

        public int? Age { get; set; }

        public string? CustomerAddress { get; set; }

        public string? Sex { get; set; }

        public string Log { get; set; }

    }
}
