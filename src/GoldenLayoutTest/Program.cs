using Blazor.GoldenLayout;
using GoldenLayoutTest;
using GoldenLayoutTest.Pages;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });


builder.Services.RegisterGoldenLayoutService(new Dictionary<Type, string>
{
    { typeof(Counter), "Counter"}
});

builder.RootComponents.RegisterGoldenLayoutComponent();

await builder.Build().RunAsync();
