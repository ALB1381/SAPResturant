using SAPResturant.Application.API.Service.DTOs;
using SAPResturant.Application.API.Service.Service.Interface;

namespace SAPResturant.Application.API.EndpointSections
{
    public static class KitchenEndpoints
    {
        public static void MapKitchenEndPointAPI(this IEndpointRouteBuilder app)
        {
            var endpointGroup = app.MapGroup("/api/kitchen");

            endpointGroup.MapGet("/GetDashboardDTO", async (IAPIService service) =>
            {
                var orders = await service.GetKitchenDashboardDTOs();
                return Results.Ok(orders);
            });

            endpointGroup.MapPut("/orders/{orderId:int}/status", async (
                int orderId,
                KitchenOrderStatusUpdateDTO request,
                IAPIService service) =>
            {
                var result = await service.UpdateKitchenOrderStatus(orderId, request.Status);
                return result switch
                {
                    KitchenOrderStatusUpdateResult.Updated => Results.NoContent(),
                    KitchenOrderStatusUpdateResult.OrderNotFound => Results.NotFound(),
                    KitchenOrderStatusUpdateResult.InvalidTransition => Results.Conflict(new
                    {
                        Message = "The kitchen order status transition is not allowed."
                    }),
                    KitchenOrderStatusUpdateResult.TargetStatusNotConfigured => Results.Problem(
                        "The requested kitchen status is not configured. Apply the pending database migration.",
                        statusCode: StatusCodes.Status503ServiceUnavailable),
                    _ => Results.Problem(statusCode: StatusCodes.Status500InternalServerError)
                };
            });
        }
    }
}
