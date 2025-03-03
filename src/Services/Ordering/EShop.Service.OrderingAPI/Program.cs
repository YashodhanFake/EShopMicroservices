using EShop.Service.OrderingAPI;
using EShop.Service.OrderingApplication;
using EShop.Service.OrderingInfrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddApplicationServices(builder.Configuration)
    .AddInfrastructureServices(builder.Configuration)
    .AddApiServices(builder.Configuration);


var app = builder.Build();

//Configure the HTTPs request pineline.
app.UseApiServices();

app.Run();
