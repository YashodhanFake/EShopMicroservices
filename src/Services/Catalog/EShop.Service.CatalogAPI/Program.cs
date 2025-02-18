global using Carter;
global using Mapster;
global using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container

builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
});

var app = builder.Build();

//Configure the HTTPs request pineline

app.MapCarter();

app.Run();