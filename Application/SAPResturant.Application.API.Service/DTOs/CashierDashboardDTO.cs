using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace SAPResturant.Application.API.Service.DTOs
{
    public class CashierDashboardDTO
    {
        public int TotalSellToday { get; set; }
        public int CountOfOrderToday { get; set; }
        public List<OrderLittleInfo> InnerOrders { get; set; }
        public List<OrderLittleInfo> OuterOrders { get; set; }
        public List<TableLittleInfo> Tables { get; set; }
    }
    public class OrderLittleInfo
    {
        public int SumPrice { get; set; }
        public string OrderStatus { get; set; }
        public int? OrderTableId { get; set; }
        public int? OrderId { get; set; }
        public int? PayedTime { get; set; }
        public string? OrderTableName { get; set; }
        public bool SnapFood { get; set; }
        public string? Address { get; set; }
        public string? CustomerName { get; set; }
        public int? CustomerId { get; set; }

    }
    public class TableLittleInfo
    {
        public int TableId { get; set; }
        public string? TableName { get; set; }
        public int CountOdSeats { get; set; }
        public string Status { get; set; }

    }
}
