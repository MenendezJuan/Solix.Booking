using Microsoft.Extensions.DependencyInjection;

namespace Solix.Booking.Common
{
	public static class DependencyInjectionServices
	{
		public static IServiceCollection AddCommon(this IServiceCollection services)
		{
			return services;
		}
	}
}