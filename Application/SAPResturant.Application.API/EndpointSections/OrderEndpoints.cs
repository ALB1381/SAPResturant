namespace SAPResturant.Application.API.EndpointSections
{
    public static class OrderEndpoints
    {
        public static async void MapOrderEndpointApi(this IEndpointRouteBuilder app)
        {
            var EndpointGroup = app.MapGroup("/api/Order");
            EndpointGroup.MapPost("/CreateNewOrderFromCashier")
        }
    }
}
