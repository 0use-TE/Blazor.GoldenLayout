using Blazor.GoldenLayout;
using GoldenLayoutTest;
using GoldenLayoutTest.Pages;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

//Start
builder.Services.RegisterGoldenLayoutService(new Dictionary<Type, string>
{
    { typeof(Counter), "Counter"},
    {typeof(HelloWorld),"HelloWorld"},
});
builder.RootComponents.RegisterGoldenLayoutComponent();
//End
await builder.Build().RunAsync();
