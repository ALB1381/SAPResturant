using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPResturant.Application.API.Service.DTOs
{
    public class KitchenDashboardDTO
    {
        public int OrderId { get; set; }
        public string TableName { get; set; } = string.Empty;
        public int TableId { get; set; }
        public DateTime OrderTime { get; set; }
        public string Status { get; set; } = "Pending";
        public string? KitchenNotes { get; set; }
        public List<KitchenOrderItemDTO> Items { get; set; } = new();

    }
    public class KitchenOrderItemDTO
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public string? Notes { get; set; }
        public string Status { get; set; } = "Pending";
    }
}
