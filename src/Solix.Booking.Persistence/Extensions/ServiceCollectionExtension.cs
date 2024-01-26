using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Solix.Booking.Application.Interfaces;
using Solix.Booking.Persistence.Database;

namespace Solix.Booking.Persistence.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDbContextSqlServer(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("SolixServicios");
            services.AddDbContext<DatabaseService>(options =>
            options.UseSqlServer(connectionString), ServiceLifetime.Transient);

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IDatabaseService, DatabaseService>();
            return services;
        }
    }
}
