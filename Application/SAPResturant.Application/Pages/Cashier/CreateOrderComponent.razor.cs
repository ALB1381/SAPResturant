using Microsoft.AspNetCore.Components;
using SAPResturant.Application.DTOs;
using System.Net.Http.Json;

namespace SAPResturant.Application.Pages.Cashier
{
    public partial class CreateOrderComponent : ComponentBase
    {
        [SupplyParameterFromQuery]
        [Parameter]
        public string? lastpage { get; set; }

        private CreatNewOrderDTO? createOrderData;
        private OrderViewModel currentOrder = new();

        private int? selectedGroupId = null;
        private string searchTerm = "";

        // Modal States
        private bool showCustomizationModal = false;
        private bool showFinalizeModal = false;
        private bool showCustomerModal = false;

        // Customization Modal State
        private ShortItemInformation? selectedItemForModal;
        private OrderItemViewModel tempOrderItem = new();


        // Finalize Modal State & Customer Search
        private List<LittleCustomerInformationDTO> customerSuggestions = new();
        private bool customerNotFound = false;
        private HttpClient client = new();
        private List<SelectedExtraOnItemModel>? SelectedExtraOnItemModels { get; set; }
        public bool IsMan { get; set; }
        protected override async Task OnInitializedAsync()
        {
            SelectedExtraOnItemModels = new List<SelectedExtraOnItemModel>();
            client = HttpClientFactory.CreateClient("Api");
            try
            {
                createOrderData = await client.GetFromJsonAsync<CreatNewOrderDTO>("api/Cashier/GetCreateNewOrderFromCashierDTOs");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to fetch initial order data: {ex.Message}");
            }
        }

        // --- View Models For UI State ---
        public class OrderViewModel
        {
            public int? TableId { get; set; }
            public string? KitchenDescription { get; set; }
            public string? CustomerPhoneNumber { get; set; }
            public LittleCustomerInformationDTO? SelectedCustomer { get; set; }
            public List<OrderItemViewModel> Items { get; set; } = new();
            public decimal RawPrice => Items.Sum(i => i.TotalItemPrice);
            public decimal TaxPrice => RawPrice * 0.10m; // Example 10% tax
            public decimal SumPrice => RawPrice + TaxPrice;
        }

        public class OrderItemViewModel
        {
            public Guid UniqueId { get; set; } = Guid.NewGuid();
            public ShortItemInformation BaseItem { get; set; }
            public ShortItemOption SelectedOption { get; set; }
            public List<ShortExtraOnItem> SelectedExtras { get; set; } = new();
            public int Quantity { get; set; }
            public decimal TotalItemPrice => ((decimal)(SelectedOption?.OptionPrice ?? BaseItem.Price ?? 0) + (decimal)(SelectedExtras.Sum(e => e.ExtraOnItemPrice) ?? 0)) * Quantity;
        }

        public class LittleCustomerInformationDTO
        {
            public int CustomerId { get; set; }
            public string CustomerName { get; set; }
            public string CustomerPhoneNumber { get; set; }
        }

        private class SelectedExtraOnItemModel
        {

            public int Id { get; set; }
            public int CaseId { get; set; }
        }

        private IEnumerable<ShortItemInformation> GetFilteredItems()
        {
            if (createOrderData == null) return Enumerable.Empty<ShortItemInformation>();

            var query = createOrderData.ShortItemInformation.AsEnumerable();
            if (selectedGroupId != null)
            {
                query = query.Where(i => i.ShortGroupInformation?.GroupId == selectedGroupId);
            }
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = query.Where(i => i.ItemName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
            }
            return query;
        }

        private void FilterItems(int? groupId) => selectedGroupId = groupId;

        private void OpenCustomizationModal(ShortItemInformation item)
        {
            selectedItemForModal = item;
            var defaultOption = item.ItemOptions?.FirstOrDefault();

            tempOrderItem = new OrderItemViewModel { BaseItem = item, SelectedOption = defaultOption };
            showCustomizationModal = true;
        }

        private void CloseCustomizationModal() => showCustomizationModal = false;
        private void OpenFinalizeModal() => showFinalizeModal = true;
        private void CloseFinalizeModal()
        {
            showFinalizeModal = false;
            customerSuggestions.Clear();
            customerNotFound = false;
        }
        private void CloseCustomerModal()
        {
            showCustomerModal = false;
        }

        private async Task HandlePhoneNumberInput(ChangeEventArgs e)
        {
            currentOrder.CustomerPhoneNumber = e.Value?.ToString();
            customerNotFound = false;
            customerSuggestions.Clear();
            currentOrder.SelectedCustomer = null;

            if (!string.IsNullOrWhiteSpace(currentOrder.CustomerPhoneNumber) && currentOrder.CustomerPhoneNumber.Length > 2)
            {
                try
                {
                    customerSuggestions = await client.GetFromJsonAsync<List<LittleCustomerInformationDTO>>($"api/Customer/GetUserNamesByPhoneNumber/{currentOrder.CustomerPhoneNumber}");
                    if (customerSuggestions == null || !customerSuggestions.Any())
                    {
                        customerNotFound = true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to fetch customers: {ex.Message}");
                    customerNotFound = true;
                }
            }
        }

        private void SelectCustomer(LittleCustomerInformationDTO customer)
        {
            currentOrder.SelectedCustomer = customer;
            currentOrder.CustomerPhoneNumber = customer.CustomerPhoneNumber;
            customerSuggestions.Clear();
            customerNotFound = false;
        }

        private void ToggleExtra(ShortExtraOnItem extra, bool isChecked, int CaseId)
        {
            if (isChecked)
            {
                if (!tempOrderItem.SelectedExtras.Contains(extra))
                    tempOrderItem.SelectedExtras.Add(extra);
                SelectedExtraOnItemModels.Add(new SelectedExtraOnItemModel { Id = extra.ExtraOnItemId, CaseId = CaseId });
            }
            else
            {
                tempOrderItem.SelectedExtras.Remove(extra);
                SelectedExtraOnItemModels.Remove(SelectedExtraOnItemModels.FirstOrDefault(q => q.Id == extra.ExtraOnItemId && q.CaseId == CaseId));
            }
        }

        private void AddItemToOrderFromModal()
        {
            if (tempOrderItem.SelectedOption == null)
            {
                if (selectedItemForModal?.ItemOptions?.Count == 1)
                {
                    tempOrderItem.SelectedOption = selectedItemForModal.ItemOptions.First();
                }
                else if (selectedItemForModal?.Price != null)
                {
                    tempOrderItem.SelectedOption = new ShortItemOption { OptionId = 0, OptionTitle = "Standard", OptionPrice = selectedItemForModal.Price ?? 0 };
                }
                else
                {
                    return;
                }
            }

            tempOrderItem.Quantity = 1;
            currentOrder.Items.Add(tempOrderItem);

            CloseCustomizationModal();
        }

        private void IncrementItem(Guid uniqueId)
        {
            var item = currentOrder.Items.FirstOrDefault(i => i.UniqueId == uniqueId);
            if (item != null) item.Quantity++;
        }

        private void DecrementItem(Guid uniqueId)
        {
            var item = currentOrder.Items.FirstOrDefault(i => i.UniqueId == uniqueId);
            if (item != null)
            {
                if (item.Quantity > 1) item.Quantity--;
                else currentOrder.Items.Remove(item);
            }
        }




        private async Task SubmitOrder(int paymentMethodId)
        {
            //To Do: User Cashier User Name in Mader Log
            var orderDto = new CreateNewOrderFormDTO
            {
                CustomerId = currentOrder.SelectedCustomer?.CustomerId,
                CustomerName = currentOrder.SelectedCustomer == null ? "Guest" : currentOrder.SelectedCustomer.CustomerName,
                CustomerPhoneNumber = currentOrder.CustomerPhoneNumber,
                Description = currentOrder.KitchenDescription,
                IsMan = IsMan,
                OrderType = "Inner",
                LogFromClient = "Made From Cashier {Cashier User Name}",
                TableId = currentOrder.TableId,
                SubOrders = currentOrder.Items.SelectMany(item =>
                {
                    var subOrders = new List<SubOrderLittleInformationDTO>
                {
                    new SubOrderLittleInformationDTO
                    {
                        ItemCaseId = item.SelectedOption.OptionId,
                        Count = item.Quantity,
                        ExtraOnItemId = SelectedExtraOnItemModels
                            .Where(e => e.CaseId == item.BaseItem.ItemId)
                            .Select(e => e.Id)
                            .ToList()
                    }
                };
                    return subOrders;
                }).ToList()


            };

            try
            {

                var response = await client.PostAsJsonAsync("api/Order/CreateNewOrderFromCashier", orderDto);
                if (response.IsSuccessStatusCode)
                {
                    // Order created successfully, reset for the next one
                    currentOrder = new OrderViewModel();
                    CloseFinalizeModal();
                    StateHasChanged();
                    // Optionally navigate to a success page or dashboard
                    // NavigationManager.NavigateTo("/dashboard");
                    ReloadPage();
                }
                else
                {
                    Console.WriteLine($"Error creating order: {response.ReasonPhrase}");
                    // Handle error display to the user
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception during order creation: {ex.Message}");
            }
        }

        private void DetermineSexOfCustomer(string Sex)
        {
            if (Sex == "Man")
            {
                IsMan = true;
            }
            else if (Sex == "Woman")
            {
                IsMan = false;
            }
        }

        private void ReloadPage()
        {
            NavigationManager.NavigateTo(NavigationManager.Uri, true);
        }

        private async Task HandleCustomerSaved(CreateNewCustomerDTO newCustomer)
        {
            newCustomer.Log = "From-Cashier-inOrderMade";
            var response = await client.PostAsJsonAsync("api/Customer/AddCustomer", newCustomer);
            if (response.IsSuccessStatusCode)
            {
                currentOrder.SelectedCustomer = new LittleCustomerInformationDTO();
                customerNotFound = false;
                customerSuggestions.Clear();
                currentOrder.SelectedCustomer = null;
                currentOrder.CustomerPhoneNumber = newCustomer.CustomerPhoneNumber;
                showCustomerModal = false;
            }
           
        }
    }
}
