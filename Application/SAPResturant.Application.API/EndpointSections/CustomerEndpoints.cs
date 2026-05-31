using SAPResturant.Application.API.Service.DTOs;
using SAPResturant.Application.API.Service.Service.Interface;

namespace SAPResturant.Application.API.EndpointSections
{
    public static class CustomerEndpoints
    {
        public static async void MapCustomerEndpointApi(this IEndpointRouteBuilder app)
        {
            var EndpointGroup = app.MapGroup("/api/Customer");

            EndpointGroup.MapGet("/GetUserNamesByPhoneNumber/{phoneNumber}", async (string phoneNumber, IAPIService service) => {
                var data = await service.GetCustomerLittleInformationDTOByPhoneNumber(phoneNumber);
                return Results.Ok(data);
            });

            EndpointGroup.MapPost("/AddCustomer", async (CreateNewCustomerDTO dto, IAPIService service) => {
                await service.CreateNewCustomer(dto);
                return Results.Created();
            });
        }
    }
}
