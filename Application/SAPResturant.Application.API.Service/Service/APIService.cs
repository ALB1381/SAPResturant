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
                var newCustomer = new Customer()
                {
                    Address = ExDto.CustomerAddress,
                    CustomerName = ExDto.CustomerName,
                    Age = ExDto.Age,
                    CustomerPhone = ExDto.CustomerPhoneNumber,
                    IsMan = (ExDto.Sex == "Man") ? true : false,
                    MaderLog = ExDto.Log ?? string.Empty,
                    FirstShop = DateTime.Now
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

        public async Task<int> CreateNewOrderFromCashier(CreateNewOrderFormDTO createNewOrderFormDTO)
        {
            if (createNewOrderFormDTO.OrderType != "Inner")
            {
                throw new ArgumentException("Only dine-in and takeout inner orders are supported.");
            }

            if (createNewOrderFormDTO.SubOrders.Count == 0 || createNewOrderFormDTO.SubOrders.Any(item => item.Count <= 0))
            {
                throw new ArgumentException("An order must contain items with a positive quantity.");
            }

            if (createNewOrderFormDTO.Description?.Length > 300)
            {
                throw new ArgumentException("Kitchen notes cannot exceed 300 characters.");
            }

            if (createNewOrderFormDTO.CustomerId.HasValue && createNewOrderFormDTO.NewCustomer is not null)
            {
                throw new ArgumentException("Choose an existing customer or enter a new customer, not both.");
            }

            await using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var itemCaseIds = createNewOrderFormDTO.SubOrders
                    .Select(item => item.ItemCaseId)
                    .Distinct()
                    .ToList();
                var extraIds = createNewOrderFormDTO.SubOrders
                    .Where(item => item.ExtraOnItemId is not null)
                    .SelectMany(item => item.ExtraOnItemId!)
                    .Distinct()
                    .ToList();

                var itemCases = await _context.ItemCases
                    .Where(itemCase => itemCaseIds.Contains(itemCase.ItemCaseId))
                    .ToDictionaryAsync(itemCase => itemCase.ItemCaseId);
                if (itemCases.Count != itemCaseIds.Count)
                {
                    throw new ArgumentException("One or more selected menu options no longer exist.");
                }

                var extras = await _context.ExtraOnItems
                    .Where(extra => extraIds.Contains(extra.ExtraOnItemId))
                    .ToDictionaryAsync(extra => extra.ExtraOnItemId);
                if (extras.Count != extraIds.Count)
                {
                    throw new ArgumentException("One or more selected extras no longer exist.");
                }

                var extraConnections = await _context.ExtraOnItemItemConnections
                    .Where(connection => extraIds.Contains(connection.ExtraOnItemId))
                    .Select(connection => new { connection.ItemId, connection.ExtraOnItemId })
                    .ToListAsync();

                foreach (var item in createNewOrderFormDTO.SubOrders)
                {
                    var selectedExtras = item.ExtraOnItemId ?? new List<int>();
                    if (selectedExtras.Distinct().Count() != selectedExtras.Count)
                    {
                        throw new ArgumentException("An extra cannot be selected more than once for the same item.");
                    }

                    var itemId = itemCases[item.ItemCaseId].ItemId;
                    if (selectedExtras.Any(extraId => !extraConnections.Any(connection =>
                            connection.ItemId == itemId && connection.ExtraOnItemId == extraId)))
                    {
                        throw new ArgumentException("An extra was selected for a menu item that does not offer it.");
                    }
                }

                var orderTable = createNewOrderFormDTO.TableId.HasValue
                    ? await _context.Tables.FirstOrDefaultAsync(table => table.TableId == createNewOrderFormDTO.TableId.Value)
                    : null;
                if (createNewOrderFormDTO.TableId.HasValue && orderTable is null)
                {
                    throw new ArgumentException("The selected table does not exist.");
                }

                var takenStatus = orderTable is null
                    ? null
                    : await _context.TableStatuses.FirstOrDefaultAsync(status => status.TableStatusName == "Taken");
                if (orderTable is not null && takenStatus is null)
                {
                    throw new InvalidOperationException("The Taken table status is not configured.");
                }
                if (orderTable is not null)
                {
                    orderTable.TableStatusId = takenStatus!.TableStatusId;
                }

                var paymentMethod = await _context.PaymentMethods
                    .FirstOrDefaultAsync(method => method.MethodId == createNewOrderFormDTO.PaymentMethodId);
                if (paymentMethod is null)
                {
                    throw new ArgumentException("The selected payment method is not configured. Apply the pending database migration.");
                }

                var orderStatus = await _context.OrderStatuses
                    .FirstOrDefaultAsync(status => status.StatusName == "Initialized");
                if (orderStatus is null)
                {
                    throw new InvalidOperationException("The Initialized order status is not configured.");
                }

                SAPResturant.Inner.Data.Entities.Customers.Customer customer;
                if (createNewOrderFormDTO.CustomerId.HasValue)
                {
                    customer = await _context.Customers
                        .FirstOrDefaultAsync(existingCustomer => existingCustomer.CustomerId == createNewOrderFormDTO.CustomerId.Value)
                        ?? throw new ArgumentException("The selected customer does not exist.");
                }
                else
                {
                    var newCustomer = createNewOrderFormDTO.NewCustomer;
                    var customerName = newCustomer?.CustomerName ?? createNewOrderFormDTO.CustomerName ?? "Guest";
                    var phone = newCustomer?.CustomerPhoneNumber ?? createNewOrderFormDTO.CustomerPhoneNumber;
                    var address = newCustomer?.CustomerAddress;
                    var age = newCustomer?.Age;

                    if (customerName.Length > 100 || phone?.Length > 15 || address?.Length > 800 || age is < 0 or > 255)
                    {
                        throw new ArgumentException("The new customer details exceed the allowed limits.");
                    }

                    customer = new SAPResturant.Inner.Data.Entities.Customers.Customer
                    {
                        CustomerName = customerName,
                        CustomerPhone = phone,
                        Address = address,
                        Age = age,
                        IsMan = newCustomer is null ? createNewOrderFormDTO.IsMan : newCustomer.Sex == "Man",
                        FirstShop = DateTime.UtcNow,
                        MaderLog = "Cashier"
                    };
                    _context.Customers.Add(customer);
                }

                var subInnerOrders = new List<SubInnerOrder>();
                var rawPrice = 0;
                foreach (var item in createNewOrderFormDTO.SubOrders)
                {
                    var itemCase = itemCases[item.ItemCaseId];
                    var selectedExtras = item.ExtraOnItemId ?? new List<int>();
                    var extrasTotal = selectedExtras.Sum(extraId => extras[extraId].ExtraOnItemPrice ?? 0);
                    var singlePrice = checked(itemCase.CasePrice + extrasTotal);
                    var sumPrice = checked(singlePrice * item.Count);
                    rawPrice = checked(rawPrice + sumPrice);

                    subInnerOrders.Add(new SubInnerOrder
                    {
                        Count = item.Count,
                        SinglePrice = singlePrice,
                        SumPrice = sumPrice,
                        MadeDate = DateTime.UtcNow,
                        ItemCaseID = item.ItemCaseId,
                        ExtraOnItemId = selectedExtras.Count > 0 ? selectedExtras[0] : null,
                        ExtraConnections = selectedExtras.Select(extraId => new SubInnerOrderExtraOnItemConnection
                        {
                            ExtraOnItemId = extraId
                        }).ToList(),
                        MaderLog = "Cashier"
                    });
                }

                var taxPrice = (int)Math.Round(rawPrice * 0.10, MidpointRounding.AwayFromZero);
                var sumPriceTotal = checked(rawPrice + taxPrice);
                var now = DateTime.UtcNow;
                var newOrder = new InnerOrder
                {
                    Customer = customer,
                    TableId = createNewOrderFormDTO.TableId,
                    OrderDescription = createNewOrderFormDTO.Description,
                    OrderDate = now,
                    OrderStatusId = orderStatus.OrderStatusId,
                    MaderLog = "Cashier",
                    RawPrice = rawPrice,
                    TaxPrice = taxPrice,
                    SumPrice = sumPriceTotal,
                    SubInnerOrders = subInnerOrders,
                    Transactions = new List<Transaction>
                    {
                        new()
                        {
                            TransactionSum = paymentMethod.Free ? 0 : sumPriceTotal,
                            TransactionCreateDate = now,
                            TransactionPayedTime = now,
                            PaymentMethodId = paymentMethod.MethodId,
                            IsPayed = true,
                            MaderLog = "Cashier"
                        }
                    }
                };

                _context.InnerOrders.Add(newOrder);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                return newOrder.InnerOrderId;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
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
            return await _context.Customers.AsNoTracking().Where(c => c.CustomerPhone.Contains(phoneNumber)).Select(c => new LittleCustomerInformationDTO()
            {
                CustomerId = c.CustomerId,
                CustomerName = c.CustomerName,
                CustomerPhoneNumber = c.CustomerPhone
            }).ToListAsync();
        }

        public async Task<List<KitchenDashboardDTO>> GetKitchenDashboardDTOs()
        {
            var sql = @"
        -- Result Set 1: Active Kitchen Orders
        SELECT DISTINCT
            o.InnerOrderId AS OrderId,
            ISNULL(t.TableName, 'Takeout/No Table') AS TableName,
            ISNULL(o.TableId, 0) AS TableId,
            o.OrderDate AS OrderTime,
            CASE os.StatusName
                WHEN 'Initialized' THEN 'Pending'
                WHEN 'Sent to kitchen' THEN 'Pending'
                ELSE os.StatusName
            END AS Status,
            o.OrderDescription AS KitchenNotes
        FROM dbo.InnerOrders o
        LEFT JOIN dbo.Tables t ON o.TableId = t.TableId
        INNER JOIN dbo.OrderStatuses os ON o.OrderStatusId = os.OrderStatusId
        INNER JOIN dbo.SubInnerOrders sio ON o.InnerOrderId = sio.InnerOrderId
        INNER JOIN dbo.ItemCases ic ON sio.ItemCaseID = ic.ItemCaseId
        INNER JOIN dbo.Items i ON ic.ItemId = i.ItemId
        WHERE os.StatusName IN ('Initialized', 'Sent to kitchen', 'Cooking', 'Ready')
          AND i.ItemUnitId = 2
        ORDER BY o.OrderDate ASC;

        -- Result Set 2: The items inside active kitchen orders
        SELECT
            sio.InnerOrderId AS OrderId,
            i.ItemId,
            i.ItemName,
            sio.Count AS Quantity,
            extra.ExtraOnItemTitle AS Notes
        FROM dbo.SubInnerOrders sio
        INNER JOIN dbo.InnerOrders o ON sio.InnerOrderId = o.InnerOrderId
        INNER JOIN dbo.OrderStatuses os ON o.OrderStatusId = os.OrderStatusId
        INNER JOIN dbo.ItemCases ic ON sio.ItemCaseID = ic.ItemCaseId
        INNER JOIN dbo.Items i ON ic.ItemId = i.ItemId
        LEFT JOIN dbo.ExtraOnItems extra ON sio.ExtraOnItemId = extra.ExtraOnItemId
        WHERE os.StatusName IN ('Initialized', 'Sent to kitchen', 'Cooking', 'Ready')
          AND i.ItemUnitId = 2;
    ";

            var db = _context.Database.GetDbConnection();
            using (var multi = await db.QueryMultipleAsync(sql))
            {
                var orders = (await multi.ReadAsync<KitchenDashboardDTO>()).ToList();
                var allItems = await multi.ReadAsync<dynamic>();

                foreach (var order in orders)
                {
                    order.Items = allItems
                        .Where(item => item.OrderId == order.OrderId)
                        .Select(item => new KitchenOrderItemDTO
                        {
                            ItemId = item.ItemId,
                            ItemName = item.ItemName,
                            Quantity = item.Quantity,
                            Notes = item.Notes
                        })
                        .ToList();
                }

                return orders;
            }
        }

        public async Task<KitchenOrderStatusUpdateResult> UpdateKitchenOrderStatus(int orderId, string status)
        {
            var order = await _context.InnerOrders
                .Include(innerOrder => innerOrder.OrderStatus)
                .FirstOrDefaultAsync(innerOrder => innerOrder.InnerOrderId == orderId);

            if (order is null)
            {
                return KitchenOrderStatusUpdateResult.OrderNotFound;
            }

            var currentStatus = order.OrderStatus?.StatusName;
            var isValidTransition = status switch
            {
                "Cooking" => currentStatus is "Initialized" or "Sent to kitchen",
                "Ready" => currentStatus == "Cooking",
                _ => false
            };

            if (!isValidTransition)
            {
                return KitchenOrderStatusUpdateResult.InvalidTransition;
            }

            var targetStatus = await _context.OrderStatuses
                .FirstOrDefaultAsync(orderStatus => orderStatus.StatusName == status);

            if (targetStatus is null)
            {
                return KitchenOrderStatusUpdateResult.TargetStatusNotConfigured;
            }

            order.OrderStatusId = targetStatus.OrderStatusId;
            await _context.SaveChangesAsync();

            return KitchenOrderStatusUpdateResult.Updated;
        }

        public async Task RemoveInnerOrderFromCashier(int OrderId)
        {
            var record = await _context.InnerOrders.FindAsync(OrderId);
            if (record != null)
            {
                _context.InnerOrders.Remove(record);
                await _context.SaveChangesAsync();
            }
        }
    }
}
