using BuidingBlocks.Exceptions.Handler;

namespace EShop.Service.OrderingAPI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddExceptionHandler<CustomExceptionHandler>();

            return services;
        }

        public static WebApplication UseApiServices(this WebApplication app)
        {
            app.UseExceptionHandler(options => { });

            return app;
        }
    }
}
