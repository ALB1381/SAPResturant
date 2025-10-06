using SAPResturant.Application.API.Service.Service.Interface;

namespace SAPResturant.Application.API.EndpointSections
{
    public static class CashierEndpoints
    {            
        public static async void MapCashierEndpointApi(this IEndpointRouteBuilder app)
        {
            var EndpointGroup = app.MapGroup("/api/Cashier");
            EndpointGroup.MapGet("/", async (IAPIService service) => {
                var data = await service.GetCashierDashboardInformationDTO();
                return Results.Ok(data);
            });
        }
    }
}
