using Microsoft.Extensions.DependencyInjection;
using UnitOfWorkAndxUnit.Application.Interfaces;
using UnitOfWorkAndxUnit.Application.Services;

namespace UnitOfWorkAndxUnit.Application
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IReportingService, ReportingService>();
            return services;
        }
    }
}
