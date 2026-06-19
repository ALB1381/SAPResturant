using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SAPResturant.Application;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddMudServices();

builder.Services.AddHttpClient("Api", client =>
{
    // IMPORTANT: Replace this with your actual API address
    client.BaseAddress = new Uri("https://localhost:7072/");
});
await builder.Build().RunAsync();
