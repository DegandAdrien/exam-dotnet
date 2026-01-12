using AspireApp.ApiService;
using AspireApp.ApiService.dtos;
using AspireApp.ApiService.response;
using AspireApp.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire client integrations.
builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddProblemDetails();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();


builder.Services.AddDbContext<AspireAppDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("postgres"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

string[] summaries =
    ["Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"];

var productService = ProductSingleton.GetInstance();
var discountService = DiscountSingleton.GetInstance();
var orderSingleton = OrderSingleton.GetInstance();

app.MapGet("/db/products", async ([FromServices] AspireAppDbContext db) => await db.Products.ToListAsync());

app.MapGet("/products", () => productService.GetProducts());

app.MapPost("/orders", (OrdersProductDto ordersProductDto) =>
{
    OrderResponse orderResponse = orderSingleton.OrderProducts(ordersProductDto);

    if (orderResponse.success == false)
    {
        Console.WriteLine(orderResponse.errors);
        return Results.BadRequest(orderResponse.errors);
    }

    return Results.Ok(new OrderResponseDto(orderResponse));
});

app.MapGet("/", () => "API service is running. Navigate to /weatherforecast to see sample data.");

app.MapGet("/weatherforecast", () =>
    {
        var forecast = Enumerable.Range(1, 5).Select(index =>
                new WeatherForecast
                (
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    summaries[Random.Shared.Next(summaries.Length)]
                ))
            .ToArray();
        return forecast;
    })
    .WithName("GetWeatherForecast");

app.MapDefaultEndpoints();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}