using TopBooks6_MinimalWebAPI.Data;
using TopBooks6_Shared;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
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
    b.WithOrigins("https://localhost:7243"); 
    b.AllowAnyHeader();
    b.AllowAnyMethod();
});

app.MapGet("/book", async (IBookRepository repo) => {
    var books = await repo.GetAll();
    if (books.Count() == 0) return Results.NoContent();
    return Results.Ok(books);
});

app.MapGet("/book/{id:int}", async (int id, IBookRepository repo) =>
{
    var book = await repo.GetBook(id);
    if (book == null) return Results.NoContent();
    return Results.Ok(book);
}).WithName("GetOneBook");

app.MapPost("/book", async (Book book, IBookRepository repo) => { 

    // Validate incoming data

    await repo.Add(book);
    return Results.CreatedAtRoute("GetOneBook", new { id = book.Id}, book);
});

app.UseStaticFiles();

app.Run();

