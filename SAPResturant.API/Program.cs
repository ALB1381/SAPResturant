using Microsoft.EntityFrameworkCore;
using SAPResturant.Data.Context;
using SAPResturant.Inner.Data.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SAPInnerResturantContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SAPInnerConnection"));
}
);
builder.Services.AddControllers();

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();