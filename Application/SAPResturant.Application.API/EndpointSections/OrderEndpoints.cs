using SAPResturant.Application.API.Service.DTOs;
using SAPResturant.Application.API.Service.Service.Interface;

namespace SAPResturant.Application.API.EndpointSections
{
    public static class OrderEndpoints
    {
        public static void MapOrderEndpointApi(this IEndpointRouteBuilder app)
        {
            var endpointGroup = app.MapGroup("/api/Order");
            endpointGroup.MapPost("/CreateNewOrderFromCashier", async (CreateNewOrderFormDTO dto, IAPIService service) =>
            {
                try
                {
                    var orderId = await service.CreateNewOrderFromCashier(dto);
                    return Results.Created($"/api/Order/{orderId}", new { OrderId = orderId });
                }
                catch (ArgumentException ex)
                {
                    return Results.BadRequest(new { Error = ex.Message });
                }
            });
            endpointGroup.MapGet("/DeleteOrder/{OrderId}", async (int OrderId, IAPIService service) =>
            {
                await service.RemoveInnerOrderFromCashier(OrderId);
                return Results.Ok();
            });
        }
    }
}
