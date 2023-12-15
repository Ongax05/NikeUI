using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using NikeUI;
using NikeUI.ApiServices;
using NikeUI.ApiServices.Interfaces;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5181") });
builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();

await builder.Build().RunAsync();
