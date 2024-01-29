using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Solix.Booking.Persistence.Extensions;

namespace Solix.Booking.Persistence
{
	public static class DependencyInjectionServices
	{
		public static IServiceCollection AddPersistence(this IServiceCollection services,
		IConfiguration configuration)
		{
			// Configuración de servicios
			services.AddDbContextSqlServer(configuration);
			services.AddServices();
			return services;
		}
	}
}
