using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Solix.Booking.External
{
	public static class DependencyInjectionServices
	{
		public static IServiceCollection AddExternal(this IServiceCollection services,
			IConfiguration configuration)
		{
			return services;
		}
	}
}
