using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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

        public async Task<int> CreateNewCustomer(CreateNewCustomerDTO ExDto)
        {
           await using var transacton = await _context.Database.BeginTransactionAsync();

            try
            {
                var newCustomer = new Customer() {
                    Address=ExDto.CustomerAddress,CustomerName= ExDto.CustomerName,
                    Age=ExDto.Age,CustomerPhone=ExDto.CustomerPhoneNumber,
                    IsMan=(ExDto.Sex== "Man")?true : false,MaderLog= ExDto.Log ?? string.Empty,FirstShop= DateTime.Now
                };
               
               _context.Customers.Add(newCustomer);
                await _context.SaveChangesAsync();
                await transacton.CommitAsync();
                return newCustomer.CustomerId;

            }
            catch 
            {
                await transacton.RollbackAsync();
                return 0;
            }
        }

        public async Task CreateNewOrderFromCashier(CreateNewOrderFormDTO createNewOrderFormDTO)
        {
            // Use a transaction to ensure atomicity.
            await using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                // 1. Handle Customer: Use existing or create a new one.
                int? finalCustomerId = createNewOrderFormDTO.CustomerId;
                if (!finalCustomerId.HasValue)
                {
                    finalCustomerId = await CreateNewCustomer(new CreateNewCustomerDTO() {CustomerName= createNewOrderFormDTO.CustomerName,CustomerPhoneNumber=createNewOrderFormDTO.CustomerPhoneNumber});
                 
                }

                // 2. Create the Order (Inner or Outer).
                if (createNewOrderFormDTO.OrderType == "Inner")
                {
                    var subDtos = createNewOrderFormDTO.SubOrders ?? new List<SubOrderLittleInformationDTO>();

                    // Gather ids to minimize DB roundtrips
                    var caseIds = subDtos.Select(s => s.ItemCaseId).Distinct().ToList();
                    var extraIds = subDtos.Where(s => s.ExtraOnItemId != null)
                                          .SelectMany(s => s.ExtraOnItemId!)
                                          .Distinct()
                                          .ToList();

                    var itemCases = await _context.ItemCases.Where(ic => caseIds.Contains(ic.ItemCaseId)).ToListAsync();
                    var extras = await _context.ExtraOnItems.Where(e => extraIds.Contains(e.ExtraOnItemId)).ToListAsync();

                    // Build sub-order entities (without InnerOrderId yet)
                    var subInnerOrders = new List<SubInnerOrder>();
                    int rawPrice = 0;

                    foreach (var sd in subDtos)
                    {
                        var itemCase = itemCases.FirstOrDefault(c => c.ItemCaseId == sd.ItemCaseId);
                        int casePrice = itemCase?.CasePrice ?? 0;

                        int extrasSum = 0;
                        if (sd.ExtraOnItemId != null && sd.ExtraOnItemId.Any())
                        {
                            foreach (var exId in sd.ExtraOnItemId)
                            {
                                var ex = extras.FirstOrDefault(e => e.ExtraOnItemId == exId);
                                extrasSum += ex?.ExtraOnItemPrice ?? 0;
                            }
                        }

                        int singlePrice = casePrice + extrasSum;
                        int sumPrice = singlePrice * sd.Count;
                        rawPrice += sumPrice;

                        var sub = new SubInnerOrder
                        {
                            Count = sd.Count,
                            SinglePrice = singlePrice,
                            SumPrice = sumPrice,
                            MadeDate = DateTime.UtcNow,
                            CookedTime = DateTime.UtcNow,
                            DeliveredTime = DateTime.UtcNow,
                            ItemCaseID = sd.ItemCaseId,
                            // FK will be set after parent order is created; store first extra id (if any)
                            ExtraOnItemId = sd.ExtraOnItemId?.FirstOrDefault(),
                            MaderLog = createNewOrderFormDTO.LogFromClient ?? string.Empty
                        };

                        subInnerOrders.Add(sub);
                    }

                    // Tax and total (use 10% as in UI)
                    int taxPrice = (int)Math.Round(rawPrice * 0.10);
                    int sumPriceTotal = rawPrice + taxPrice;

                    // Create parent order first (without attaching children)
                    var newOrder = new InnerOrder
                    {
                        CustomerId = finalCustomerId,
                        TableId = createNewOrderFormDTO.TableId,
                        OrderDescription = createNewOrderFormDTO.Description,
                        OrderDate = DateTime.UtcNow,
                        OrderStatusId = 1, // default new order status
                        MaderLog = createNewOrderFormDTO.LogFromClient ?? string.Empty,
                        RawPrice = rawPrice,
                        TaxPrice = taxPrice,
                        SumPrice = sumPriceTotal
                    };

                    _context.InnerOrders.Add(newOrder);
                    // Save to get generated InnerOrderId
                    await _context.SaveChangesAsync();

                    // Now set the FK for each sub-order and insert them
                    foreach (var sub in subInnerOrders)
                    {
                        sub.InnerOrderId = newOrder.InnerOrderId;
                    }

                    if (subInnerOrders.Any())
                    {
                        _context.SubInnerOrders.AddRange(subInnerOrders);
                        await _context.SaveChangesAsync();
                    }
                }

                await transaction.CommitAsync();
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw; // Propagate the error.
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
