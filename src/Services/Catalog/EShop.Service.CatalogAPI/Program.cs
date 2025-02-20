global using Carter;
global using Mapster;
global using MediatR;
global using Marten;
global using BuidingBlocks.CQRS;
global using EShop.Service.CatalogAPI.Domain.Entities;
global using EShop.Service.CatalogAPI.Exceptions;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                     .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true);


// Add services to the container

builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
});
builder.Services.AddMarten(opt =>
{
    opt.Connection(builder.Configuration.GetConnectionString("Database")!);
}).UseLightweightSessions();

var app = builder.Build();

//Configure the HTTPs request pineline

app.MapCarter();

app.Run();