namespace SAPResturant.Application.DTOs
{
    public class WaiterDashboardDTO
    {
        public List<KitchenDashboardDTO> ReadyOrders { get; set; } = new();
        public List<WaiterUnpaidOrderDTO> UnpaidOrders { get; set; } = new();
        public List<TableLittleInfo> Tables { get; set; } = new();
        public List<WaiterTableCallDTO> TableCalls { get; set; } = new();
    }

    public class WaiterUnpaidOrderDTO
    {
        public int OrderId { get; set; }
        public string TableName { get; set; } = string.Empty;
        public int SumPrice { get; set; }
        public DateTime OrderTime { get; set; }
    }

    public class WaiterTableCallDTO
    {
        public int CallId { get; set; }
        public int TableId { get; set; }
        public string TableName { get; set; } = string.Empty;
        public DateTime CreatedAtUtc { get; set; }
        public string Status { get; set; } = "Waiting";
    }
}
