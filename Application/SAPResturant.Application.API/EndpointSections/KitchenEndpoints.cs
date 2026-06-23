using Microsoft.AspNetCore.Http.HttpResults;
using SAPResturant.Application.API.Service.Service.Interface;

namespace SAPResturant.Application.API.EndpointSections
{
    public static class KitchenEndpoints
    {
        public static void MapKitchenEndPointAPI(this IEndpointRouteBuilder app)
        {
            var EndpointGroup = app.MapGroup("/api/kitchen");
            EndpointGroup.MapGet("/GetDashboardDTO", async (IAPIService service) => {
              var res = await service.GetKitchenDashboardDTOs();
               return Results.Ok(res);
            });
        }
    }
}
