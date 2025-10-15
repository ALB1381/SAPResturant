
using Dapper;
using Microsoft.EntityFrameworkCore;
using SAPResturant.Application.API.Service.DTOs;
using SAPResturant.Application.API.Service.Service.Interface;
using SAPResturant.Inner.Data.Context;
using SAPResturant.Inner.Data.Entities.Customers;
using SAPResturant.Inner.Data.Entities.Orders;
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

        public async Task CreateNewOrderFromCashier(CreateNewOrderFormDTO createNewOrderFormDTO)
        {
            //First we should add many Extra on items for each Sub order 
           //

                await using var transaction = await _context.Database.BeginTransactionAsync();
                try
                {

                int? finalCustomerId = createNewOrderFormDTO.CustomerId;

                    if (!finalCustomerId.HasValue && !string.IsNullOrEmpty(createNewOrderFormDTO.CustomerName))
                    {
                        var newCustomer = new Customer
                        {
                            CustomerName = createNewOrderFormDTO.CustomerName,
                            CustomerPhone = createNewOrderFormDTO.CustomerPhoneNumber,
                            FirstShop = DateTime.UtcNow,
                    
                            IsEmailActivated = false,
                            IsPhoneNumberValidated = false,
                            MaderLog = "API_CASHIER_ORDER_CREATE"
                        };
                        _context.Customers.Add(newCustomer);
                        await _context.SaveChangesAsync();
                        finalCustomerId = newCustomer.CustomerId;
                    }


                    var itemCaseIds = createNewOrderFormDTO.SubOrders.Select(s => s.ItemCaseId).ToList();
                    var extraIds = createNewOrderFormDTO.SubOrders.Where(s => s.ExtraOnItemId.Any()).Select(s => s.ExtraOnItemId).ToList();

            
                    var itemCasePrices = await _context.ItemCases
                        .Where(ic => itemCaseIds.Contains(ic.ItemCaseId))
                        .ToDictionaryAsync(ic => ic.ItemCaseId, ic => ic.CasePrice);

                    var extraPrices = await _context.ExtraOnItems
                        .Where(e => extraIds.Contains(e.ExtraOnItemId))
                        .ToDictionaryAsync(e => e.ExtraOnItemId, e => e.ExtraOnItemPrice);

                    var subOrdersToCreate = new List<SubOuterOrder>();
                    int totalSumPrice = 0;

                    foreach (var subOrderDto in createNewOrderFormDTO.SubOrders)
                    {
                      
                        int singlePrice = itemCasePrices.GetValueOrDefault(subOrderDto.ItemCaseId, 0);
                        if (subOrderDto.ExtraOnItemId.HasValue)
                        {
                            singlePrice += (int)extraPrices.GetValueOrDefault(subOrderDto.ExtraOnItemId.Value, 0);
                        }

                        int lineItemSumPrice = singlePrice * subOrderDto.Count;
                        totalSumPrice += lineItemSumPrice;

                        // Create the SubOuterOrder entity
                        subOrdersToCreate.Add(new SubOuterOrder
                        {
                            ItemCaseID = subOrderDto.ItemCaseId,
                            ExtraOnItemId = subOrderDto.ExtraOnItemId,
                            Count = subOrderDto.Count,
                            SinglePrice = singlePrice,
                            SumPrice = lineItemSumPrice,
                            // Automatically populated columns
                            MadeDate = DateTime.UtcNow,
                            CookedTime = DateTime.UtcNow.AddMinutes(5), // Simulate 5 min cook time
                            MaderLog = "API_CASHIER_ORDER_CREATE"
                        });
                    }

                    // ======================================================================
                    // 3. Create the Main Order (OuterOrder)
                    // ======================================================================
                    // Calculate final prices (assuming a simple 9% tax for this example)
                    int rawPrice = (int)(totalSumPrice / 1.09);
                    int taxPrice = totalSumPrice - rawPrice;

                    var newOrder = new OuterOrder
                    {
                        // Link to sub-orders
                        SubOuterOrders = subOrdersToCreate,

                        // Link to customer
                        CustomerId = (int)finalCustomerId,

                        // Automatically populated columns
                        OrderDate = DateTime.UtcNow,
                        OrderStatusId = 1, // Default to 1: 'Pending'
                        SumPrice = totalSumPrice,
                        RawPrice = rawPrice,
                        TaxPrice = taxPrice,
                        DeliveryPrice = 0, // Assuming this is a takeout order with no delivery fee
                        DeliveredAddress = "Takeout Order", 
                        IsSnap = false,
                        MaderLog = $"API_CASHIER_ORDER_CREATE--{createNewOrderFormDTO.LogFromClient}",
                        OredeDescription = createNewOrderFormDTO.Description

                    };

                    _context.OuterOrders.Add(newOrder);

                    // ======================================================================
                    // 4. Save All Changes and Commit Transaction
                    // ======================================================================
                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch (Exception)
                {
                    // If anything goes wrong, roll back all the changes.
                    await transaction.RollbackAsync();
                    throw; // Re-throw the exception to notify the caller of the failure.
                }
            
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
       



        public async Task<CreatNewOrderDTO> GetCreateNewOrderFromCashierPageDTO()
        {
            var sql = @"
            -- Result Set 1: All menu items with their group info
            SELECT
                i.ItemId, i.ItemName, i.ItemImage,
                ig.ItemGroupId AS GroupId, ig.GroupName, ig.GroupCardColors AS GroupColor
            FROM dbo.Items AS i
            JOIN dbo.ItemGroups AS ig ON i.ItemGroupId = ig.ItemGroupId
            ORDER BY ig.ItemGroupId, i.ItemName;

            -- Result Set 2: All item options (from ItemCases)
            SELECT ic.ItemId, ic.ItemCaseId AS OptionId, ic.CaseTitle AS OptionTitle, ic.CasePrice AS OptionPrice
            FROM dbo.ItemCases AS ic;

            -- Result Set 3: All extra add-ons for items
            SELECT eic.ItemId, ei.ExtraOnItemId, ei.ExtraOnItemTitle AS ExtraOnItemName, ei.ExtraOnItemPrice
            FROM dbo.ExtraOnItems AS ei
            JOIN dbo.ExtraOnItemItemConnections AS eic ON ei.ExtraOnItemId = eic.ExtraOnItemId;

            -- Result Set 4: A flat list of all item groups
            SELECT ig.ItemGroupId AS GroupId, ig.GroupName, ig.GroupCardColors AS GroupColor
            FROM dbo.ItemGroups AS ig ORDER BY ig.GroupName;

            -- Result Set 5: All tables with their current status
            SELECT t.TableId, t.TableName, t.CountOfSeats AS CountOdSeats, ts.TableStatusName AS Status
            FROM dbo.Tables AS t
            LEFT JOIN dbo.TableStatuses AS ts ON t.TableStatusId = ts.TableStatusId
            ORDER BY t.TableNumber;
        ";

            var connection = _context.Database.GetDbConnection();
            using (var multi = await connection.QueryMultipleAsync(sql))
            {
                // ========================= FIX IS HERE =========================
                // 1. Read the raw, flat data from the first result set.
                var flatItems = (await multi.ReadAsync<dynamic>()).ToList();

                // 2. Use LINQ to project the flat data into your nested DTO structure.
                var items = flatItems.Select(i => new ShortItemInformation
                {
                    ItemId = i.ItemId,
                    ItemName = i.ItemName,
                    ItemImage = i.ItemImage,
                    ShortGroupInformation = new ShortGroupInformation
                    {
                        GroupId = i.GroupId,
                        GroupName = i.GroupName,
                        GroupColor = i.GroupColor
                    }
                }).ToList();
                // ===============================================================

                // The rest of the logic remains the same
                var allOptions = (await multi.ReadAsync<dynamic>()).ToList();
                var allExtras = (await multi.ReadAsync<dynamic>()).ToList();
                var allGroups = (await multi.ReadAsync<ShortGroupInformation>()).ToList();
                var allTables = (await multi.ReadAsync<TableLittleInfo>()).ToList();

                var optionsLookup = allOptions.GroupBy(o => (int)o.ItemId)
                                              .ToDictionary(g => g.Key, g => g.Select(o => new ShortItemOption { OptionId = o.OptionId, OptionTitle = o.OptionTitle, OptionPrice = o.OptionPrice }).ToList());

                var extrasLookup = allExtras.GroupBy(e => (int)e.ItemId)
                                            .ToDictionary(g => g.Key, g => g.Select(e => new ShortExtraOnItem { ExtraOnItemId = e.ExtraOnItemId, ExtraOnItemName = e.ExtraOnItemName, ExtraOnItemPrice = e.ExtraOnItemPrice }).ToList());

                foreach (var item in items)
                {
                    if (optionsLookup.TryGetValue(item.ItemId, out var options))
                    {
                        item.ItemOptions = options;
                        item.Price = options.FirstOrDefault()?.OptionPrice;
                    }

                    if (extrasLookup.TryGetValue(item.ItemId, out var extras))
                    {
                        item.ShortExtraOnItems = extras;
                    }
                }

                return new CreatNewOrderDTO
                {
                    ShortItemInformation = items,
                    ShortGroupInformation = allGroups,
                    TableLittleInfos = allTables
                };
            }
        }

        public async Task<List<LittleCustomerInformationDTO>> GetCustomerLittleInformationDTOByPhoneNumber(string phoneNumber)
        {
            return await _context.Customers.AsNoTracking().Where(c => c.CustomerPhone.Contains(phoneNumber)).Select(c=>new LittleCustomerInformationDTO()
            { 
                CustomerId = c.CustomerId,
                CustomerName = c.CustomerName,
                CustomerPhoneNumber = c.CustomerPhone
             }).ToListAsync();
        }
    }
}
