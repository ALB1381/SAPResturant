
using Dapper;
using Microsoft.EntityFrameworkCore;
using SAPResturant.Application.API.Service.DTOs;
using SAPResturant.Application.API.Service.Service.Interface;
using SAPResturant.Inner.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPResturant.Application.API.Service.Service
{
    public class APIService : IAPIService
    {
        SAPInnerResturantContext _context;
        public APIService(SAPInnerResturantContext sAPInnerResturant)
        {
                _context = sAPInnerResturant;
        }

        public async Task<CashierDashboardDTO> GetCashierDashboardInformationDTO()
        {
            var sql = @"
            -- Result Set 1: Dashboard Metrics
            SELECT
                (SELECT ISNULL(SUM(TransactionSum), 0) FROM dbo.Transactions WHERE IsPayed = 1 AND CAST(TransactionPayedTime AS DATE) = CAST(GETDATE() AS DATE)) AS TotalSellToday,
                (SELECT COUNT(InnerOrderId) FROM dbo.InnerOrders WHERE CAST(OrderDate AS DATE) = CAST(GETDATE() AS DATE)) +
                (SELECT COUNT(OuterOrderId) FROM dbo.OuterOrders WHERE CAST(OrderDate AS DATE) = CAST(GETDATE() AS DATE)) AS CountOfOrderToday;

            -- Result Set 2: Inner Orders for Today
            SELECT io.SumPrice, os.StatusName AS OrderStatus, io.TableId AS OrderTableId, io.InnerOrderId AS OrderId, DATEDIFF(minute, t.TransactionPayedTime, GETDATE()) AS PayedTime, tbl.TableName AS OrderTableName, CAST(0 AS BIT) AS SnapFood, NULL AS Address, c.CustomerName, io.CustomerId
            FROM dbo.InnerOrders AS io
            LEFT JOIN dbo.OrderStatuses AS os ON io.OrderStatusId = os.OrderStatusId
            LEFT JOIN dbo.Tables AS tbl ON io.TableId = tbl.TableId
            LEFT JOIN dbo.Customers AS c ON io.CustomerId = c.CustomerId
            LEFT JOIN dbo.Transactions AS t ON io.InnerOrderId = t.OrderId
            WHERE CAST(io.OrderDate AS DATE) = CAST(GETDATE() AS DATE)
            ORDER BY io.OrderDate DESC;

            -- Result Set 3: Outer Orders for Today
            SELECT oo.SumPrice, os.StatusName AS OrderStatus, NULL AS OrderTableId, oo.OuterOrderId AS OrderId, DATEDIFF(minute, t.TransactionPayedTime, GETDATE()) AS PayedTime, NULL AS OrderTableName, ISNULL(oo.IsSnap, 0) AS SnapFood, oo.DeliveredAddress AS Address, c.CustomerName, oo.CustomerId
            FROM dbo.OuterOrders AS oo
            LEFT JOIN dbo.OrderStatuses AS os ON oo.OrderStatusId = os.OrderStatusId
            LEFT JOIN dbo.Customers AS c ON oo.CustomerId = c.CustomerId
            LEFT JOIN dbo.Transactions AS t ON oo.OuterOrderId = t.OrderId
            WHERE CAST(oo.OrderDate AS DATE) = CAST(GETDATE() AS DATE)
            ORDER BY oo.OrderDate DESC;

            -- Result Set 4: All Tables Information
            SELECT t.TableId, t.TableName, t.CountOfSeats AS CountOdSeats, ts.TableStatusName AS Status
            FROM dbo.Tables AS t
            LEFT JOIN dbo.TableStatuses AS ts ON t.TableStatusId = ts.TableStatusId
            ORDER BY t.TableNumber;
        ";
            var dashboardDto = new CashierDashboardDTO();
            var connection = _context.Database.GetDbConnection();
            using (var multi = await connection.QueryMultipleAsync(sql))
            {
                var metrics = await multi.ReadSingleAsync<dynamic>();
                dashboardDto.TotalSellToday = (int)metrics.TotalSellToday;
                dashboardDto.CountOfOrderToday = (int)metrics.CountOfOrderToday;
                dashboardDto.InnerOrders = (await multi.ReadAsync<OrderLittleInfo>()).AsList();
                dashboardDto.OuterOrders = (await multi.ReadAsync<OrderLittleInfo>()).AsList();
                dashboardDto.Tables = (await multi.ReadAsync<TableLittleInfo>()).AsList();
            }

            return dashboardDto;
        }
    }
}
