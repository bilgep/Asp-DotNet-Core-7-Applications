using TopBooks5_Shared;
using TopBooks5_WebAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();
builder.Services.AddSingleton<ILogger, Logger<Book>>();
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
    b.WithOrigins("https://localhost:7030"); // Define the consumer application's (TopBooks5_WebAssembly) origin
    b.AllowAnyHeader();
    b.AllowAnyMethod();
});

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
