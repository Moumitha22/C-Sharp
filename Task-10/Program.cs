using Microsoft.EntityFrameworkCore;
using Task_10.Data;
using Task_10.Middleware;
using Task_10.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Registers the MVC controller services.
builder.Services.AddControllers();

// Configure In-Memory Database
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("BookStoreDB"));

// Register the service for dependency injection
builder.Services.AddScoped<IBookService, BookService>();

// Add Swagger for API documentation 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); // Generates Swagger documentation for the API endpoints.

// Builds the web application.
var app = builder.Build();

// Use exception middleware for centralized error handling.
app.UseMiddleware<ExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) // Only enable Swagger in development environment.
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection(); // Redirect HTTP requests to HTTPS.
app.UseAuthorization();
app.MapControllers(); // Maps routes to controller actions based on attributes 

app.Run(); // Starts the web server and processes incoming requests.
