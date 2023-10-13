using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using PizzaBookingAppClient;
using PizzaBookingAppClient.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7266/") });
builder.Services.AddMudServices();
builder.Services.AddTransient<HttpService>();
builder.Services.AddBlazoredLocalStorage();


await builder.Build().RunAsync();
