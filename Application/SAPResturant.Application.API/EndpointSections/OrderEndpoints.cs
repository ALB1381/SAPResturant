using SAPResturant.Application.API.Service.DTOs;
using SAPResturant.Application.API.Service.Service.Interface;

namespace SAPResturant.Application.API.EndpointSections
{
    public static class OrderEndpoints
    {
        public static async void MapOrderEndpointApi(this IEndpointRouteBuilder app)
        {
            var EndpointGroup = app.MapGroup("/api/Order");
            EndpointGroup.MapPost("/CreateNewOrderFromCashier", async (CreateNewOrderFormDTO DTo, IAPIService service) => 
            {
              await service.CreateNewOrderFromCashier(DTo);
              return Results.Created();
            });
            EndpointGroup.MapGet("/DeleteOrder/{OrderId}", async (int OrderId, IAPIService service) =>
            {
                await service.RemoveInnerOrderFromCashier(OrderId);
                return Results.Ok();
            });
        }
    }
}
