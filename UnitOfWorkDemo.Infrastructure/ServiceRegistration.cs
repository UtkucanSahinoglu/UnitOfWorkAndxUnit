using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UnitOfWorkAndxUnit.Infrastructure.Data;
using UnitOfWorkAndxUnit.Infrastructure.UnitOfWork;
using UnitOfWorkAndxUnit.Domain.Interfaces;

namespace UnitOfWorkAndxUnit.Infrastructure
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString, sql =>
                {
                    sql.MigrationsAssembly("UnitOfWorkAndxUnit.Infrastructure");
                    sql.EnableRetryOnFailure();
                }));

            services.AddScoped<IUnitOfWork, EfUnitOfWork>();
            return services;
        }
    }
}
