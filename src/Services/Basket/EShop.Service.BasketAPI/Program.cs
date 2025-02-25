global using Carter;
global using Mapster;
global using MediatR;
global using Marten;
global using FluentValidation;
global using Microsoft.Extensions.Caching.Distributed;
global using System.Text.Json;
global using BuidingBlocks.CQRS;
global using BuidingBlocks.Behaviors;
global using BuidingBlocks.Exceptions;
global using BuidingBlocks.Exceptions.Handler;
global using EShop.Service.BasketAPI.Domain.Entities;
global using EShop.Service.BasketAPI.Persistence.Repositories;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                     .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true);

// Add services to the container.
builder.Services.AddCarter(); // Registering API endpoint - Carter
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
    config.AddOpenBehavior(typeof(ValidationBehavior<,>)); //CQRS Pineline behavior: Validation Middleware - MediatR
    config.AddOpenBehavior(typeof(LoggingBehavior<,>)); //CQRS Pineline behavior: Logging Middleware - MediatR
}); // Registering MediatR
builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);  // Registering Validator - FluentValidation
builder.Services.AddMarten(opt =>
{
    opt.Connection(builder.Configuration.GetConnectionString("Database")!);
    opt.Schema.For<ShoppingCart>().Identity(x => x.Username);
}).UseLightweightSessions(); // Registering Marten ORM

builder.Services.AddScoped<IBasketRepository, BasketRepository>();
builder.Services.Decorate<IBasketRepository, CachedBasketRepository>(); // Registering decorator CachedBasketRepository - Scrutor

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetConnectionString("Redis");
}); // Registering Redis cache.

builder.Services.AddExceptionHandler<CustomExceptionHandler>(); // Registering Global Exception Handler

// Register HealthChecks
builder.Services.AddHealthChecks()
                .AddNpgSql(builder.Configuration.GetConnectionString("Database")!);

var app = builder.Build();

// Configure the HTTPs request pineline
app.MapCarter(); // Map API endpoint - Carter

app.UseExceptionHandler(options => { }); // Enable exception handling middleware

app.UseHealthChecks("/health",
    new HealthCheckOptions
    {
        ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
    });

app.Run(); // Enable HealthChecks
