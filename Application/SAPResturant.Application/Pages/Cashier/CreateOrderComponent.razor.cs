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
        private bool isSubmitting;
        private string? orderError;
        private string? menuLoadError;
        private HttpClient client = new();
        public bool IsMan { get; set; }
        protected override async Task OnInitializedAsync()
        {
            client = HttpClientFactory.CreateClient("Api");
            await LoadMenuData();
        }

        private async Task LoadMenuData()
        {
            menuLoadError = null;
            try
            {
                createOrderData = await client.GetFromJsonAsync<CreatNewOrderDTO>("api/Cashier/GetCreateNewOrderFromCashierDTOs");
                if (createOrderData is null)
                {
                    menuLoadError = "The cashier API returned no menu data.";
                }
            }
            catch (HttpRequestException ex)
            {
                menuLoadError = $"Could not load the menu: {ex.Message}";
            }
            catch (System.Text.Json.JsonException ex)
            {
                menuLoadError = $"The menu response was invalid: {ex.Message}";
            }
        }

        // --- View Models For UI State ---
        public class OrderViewModel
        {
            public int? TableId { get; set; }
            public string? KitchenDescription { get; set; }
            public string? CustomerPhoneNumber { get; set; }
            public LittleCustomerInformationDTO? SelectedCustomer { get; set; }
            public CreateNewCustomerDTO? NewCustomer { get; set; }
            public List<OrderItemViewModel> Items { get; set; } = new();
            public decimal RawPrice => Items.Sum(i => i.TotalItemPrice);
            public decimal TaxPrice => Math.Round(RawPrice * 0.10m, 0, MidpointRounding.AwayFromZero);
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
            currentOrder.NewCustomer = null;

            if (!string.IsNullOrWhiteSpace(currentOrder.CustomerPhoneNumber) && currentOrder.CustomerPhoneNumber.Length > 2)
            {
                try
                {
                    var phoneNumber = Uri.EscapeDataString(currentOrder.CustomerPhoneNumber);
                    customerSuggestions = await client.GetFromJsonAsync<List<LittleCustomerInformationDTO>>($"api/Customer/GetUserNamesByPhoneNumber/{phoneNumber}");
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
            currentOrder.NewCustomer = null;
            currentOrder.CustomerPhoneNumber = customer.CustomerPhoneNumber;
            customerSuggestions.Clear();
            customerNotFound = false;
        }

        private void ToggleExtra(ShortExtraOnItem extra, bool isChecked)
        {
            if (isChecked && !tempOrderItem.SelectedExtras.Contains(extra))
            {
                tempOrderItem.SelectedExtras.Add(extra);
            }
            else if (!isChecked)
            {
                tempOrderItem.SelectedExtras.Remove(extra);
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
            if (isSubmitting || currentOrder.Items.Count == 0)
            {
                return;
            }

            isSubmitting = true;
            orderError = null;
            var orderDto = new CreateNewOrderFormDTO
            {
                CustomerId = currentOrder.SelectedCustomer?.CustomerId,
                NewCustomer = currentOrder.NewCustomer,
                CustomerName = currentOrder.NewCustomer?.CustomerName
                    ?? currentOrder.SelectedCustomer?.CustomerName
                    ?? "Guest",
                CustomerPhoneNumber = currentOrder.CustomerPhoneNumber,
                Description = currentOrder.KitchenDescription,
                IsMan = currentOrder.NewCustomer is null ? IsMan : currentOrder.NewCustomer.Sex == "Man",
                OrderType = "Inner",
                LogFromClient = "Cashier",
                TableId = currentOrder.TableId,
                PaymentMethodId = paymentMethodId,
                SubOrders = currentOrder.Items.Select(item => new SubOrderLittleInformationDTO
                {
                    ItemCaseId = item.SelectedOption.OptionId,
                    Count = item.Quantity,
                    ExtraOnItemId = item.SelectedExtras.Select(extra => extra.ExtraOnItemId).ToList()
                }).ToList()
            };

            try
            {
                using var response = await client.PostAsJsonAsync("api/Order/CreateNewOrderFromCashier", orderDto);
                if (!response.IsSuccessStatusCode)
                {
                    var details = await response.Content.ReadAsStringAsync();
                    orderError = string.IsNullOrWhiteSpace(details)
                        ? $"The order could not be saved ({(int)response.StatusCode})."
                        : $"The order could not be saved: {details}";
                    return;
                }

                ReloadPage();
            }
            catch (HttpRequestException ex)
            {
                orderError = $"Could not reach the order service: {ex.Message}";
            }
            finally
            {
                isSubmitting = false;
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
            NavigationManager.NavigateTo("/CashierDashboard", true);
        }

        private Task HandleCustomerSaved(CreateNewCustomerDTO newCustomer)
        {
            currentOrder.NewCustomer = newCustomer;
            currentOrder.CustomerPhoneNumber = newCustomer.CustomerPhoneNumber;
            currentOrder.SelectedCustomer = null;
            customerSuggestions.Clear();
            customerNotFound = false;
            showCustomerModal = false;
            return Task.CompletedTask;
        }
    }
}
