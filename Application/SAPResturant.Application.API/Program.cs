using Microsoft.EntityFrameworkCore;
using SAPResturant.Application.API.EndpointSections;
using SAPResturant.Application.API.Service.Service;
using SAPResturant.Application.API.Service.Service.Interface;
using SAPResturant.Inner.Data.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<SAPInnerResturantContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SAPInnerConnection"));
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazorApp",
        policy =>
        {
            // IMPORTANT: Replace with the actual address of your Blazor app
            policy.WithOrigins("http://localhost:5281", "https://localhost:7013")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

builder.Services.AddScoped<IAPIService, APIService>();

// --- FIX IS HERE ---
// Add the required authorization services.
builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

// Now this line will work correctly.
app.UseAuthorization();
app.UseCors("AllowBlazorApp");
app.MapCashierEndpointApi();
app.MapCustomerEndpointApi();
app.MapOrderEndpointApi();
app.MapKitchenEndPointAPI();
app.MapGet("/", () => "Hello");

app.Run();