using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using TopBooks4.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor(); // Injecting Blazor Server service
builder.Services.AddSingleton<IBookRepository, BookRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub(); // Handles SignalR requests
app.MapFallbackToPage("/_Host"); // Handles regular HTTP Requests

app.Run();
