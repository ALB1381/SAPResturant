using Microsoft.AspNetCore.Components;
using SAPResturant.Application.DTOs;

namespace SAPResturant.Application.Pages.Cashier.Customer
{
    public partial class CreateCustomerComponent : ComponentBase
    {
        // The data model
        [Parameter]
        public CreateNewCustomerDTO DTO { get; set; } = new();

        // Determines if we render cancel/close buttons for a modal view
        [Parameter]
        public bool IsModal { get; set; } = false;

        // Events to notify the parent component
        [Parameter]
        public EventCallback<CreateNewCustomerDTO> OnSave { get; set; }

        [Parameter]
        public EventCallback OnCancel { get; set; }

        protected override void OnInitialized()
        {
            DTO ??= new CreateNewCustomerDTO();
        }

        private async Task HandleValidSubmit()
        {
            // If a parent component is listening, send the data up!
            if (OnSave.HasDelegate)
            {
                await OnSave.InvokeAsync(DTO);
            }
            else
            {
                // FALLBACK: If there is no parent (e.g., opened as a standalone page),
                // you would inject HttpClient and post it directly here.
                // await Http.PostAsJsonAsync("api/Customer", DTO);
            }
        }

        private async Task Cancel()
        {
            if (OnCancel.HasDelegate)
            {
                await OnCancel.InvokeAsync();
            }
        }
    }
}
