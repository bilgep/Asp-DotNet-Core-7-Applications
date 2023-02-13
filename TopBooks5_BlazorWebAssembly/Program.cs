using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TopBooks5_BlazorWebAssembly;
using TopBooks5_BlazorWebAssmbly.ApiServices;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


builder.Services.AddScoped(sp =>
    new HttpClient { BaseAddress = new Uri("https://localhost:7174") });
builder.Services.AddScoped<IBookApiService, BookApiService>();

await builder.Build().RunAsync();
