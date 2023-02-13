using Microsoft.AspNetCore.SignalR;
using TopBooks8_MinimalAPI.Data;
using TopBooks8_MinimalAPI.Hubs;
using TopBooks8_Shared;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();
builder.Services.AddCors();
builder.Services.AddSingleton<IBookRepository, BookRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(b => {
    b.WithOrigins("https://localhost:7223"); 
    b.AllowAnyHeader();
    b.AllowAnyMethod();
});


app.MapGet("/books", async (IBookRepository repo) =>
{
    var books = await repo.GetAll();
    if (books.Count() == 0) return Results.NoContent();
    return Results.Ok(books);
});

app.MapGet("/books/{id:int}", async (int id, IBookRepository repo) => {
    var book = await repo.GetBook(id);
    if(book == null) return Results.NoContent();
    return Results.Ok(book); 
});

app.MapPost("/books", async (Book book, IBookRepository repo, IHubContext<BookHub> hub) =>
{
    // Update repository
    await repo.Add(book);

    // Update clients
    await hub.Clients.All.SendAsync("NewBook", book);

    //return Results.CreatedAtRoute("GetBook", new { id = book.Id }, book);
    return Results.Ok(book);

});


app.MapHub<BookHub>("/bookhub");

app.Run();


