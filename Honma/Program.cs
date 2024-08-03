using Blazored.LocalStorage;
using Fluxor;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Honma;
using Honma.Authentication;
using Honma.Data;
using Honma.Services;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;
using MudBlazor.Services;
using Refit;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Register Fluxor services for state management.
builder.Services.AddFluxor(options => { options.ScanAssemblies(typeof(Program).Assembly); });

// Register API interface with Refit, including handler for populating authentication header for every HTTP request.
builder.Services.AddTransient<AuthenticationHeaderHandler>();
builder.Services
    .AddRefitClient<ISpaceTradersClient>()
    .ConfigureHttpClient(client => client.BaseAddress = new Uri("https://api.spacetraders.io/v2"))
    .AddHttpMessageHandler<AuthenticationHeaderHandler>();

// Register MudBlazor component library services.
builder.Services.AddMudServices(configuration =>
{
    configuration.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomRight;
});

// Register web local storage service.
builder.Services.AddBlazoredLocalStorage();

// Register .NET authorization.
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<ClientAuthenticationStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(provider =>
    provider.GetRequiredService<ClientAuthenticationStateProvider>());

// Register app services.
builder.Services.AddScoped<ClipboardService>();
builder.Services.AddScoped<UserTokenService>();
builder.Services.AddScoped<AgentHistoryService>();

builder.Logging.SetMinimumLevel(LogLevel.Warning);

await builder.Build().RunAsync();