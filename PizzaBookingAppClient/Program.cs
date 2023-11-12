using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor;
using MudBlazor.Services;
using PizzaBookingAppClient;
using PizzaBookingAppClient.Providers;
using PizzaBookingAppClient.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { 
	BaseAddress = new Uri("https://localhost:7266/")
});

builder.Services.AddMudServices(config =>
{
    config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomRight;

    config.SnackbarConfiguration.PreventDuplicates = false;
    config.SnackbarConfiguration.NewestOnTop = false;
    config.SnackbarConfiguration.ShowCloseIcon = true;
    config.SnackbarConfiguration.VisibleStateDuration = 500;
    config.SnackbarConfiguration.HideTransitionDuration = 1500;
    config.SnackbarConfiguration.ShowTransitionDuration = 500;
    config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
});

builder.Services.AddTransient<HttpService>();
builder.Services.AddTransient<IAuthService, AuthService>();
builder.Services.AddTransient<ICartService, CartService>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthProvider>();

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddOptions();

builder.Services.AddAuthorizationCore(options =>
{
	options.AddPolicy("admin", p =>
	{
		p.RequireClaim("role", "admin");
	});
});



await builder.Build().RunAsync();
