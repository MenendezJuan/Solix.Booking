using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Solix.Booking.Api
{
	public static class DependencyInjectionService
	{
		public static IServiceCollection AddWebApi (this IServiceCollection services)
		{
			services.AddSwaggerGen(options =>
			{
			options.SwaggerDoc("v1", new OpenApiInfo{
					Version = "v1",
					Title = "Solix Booking API",
					Description = "Administracion de APIs para Booking APP"

			});

				var fileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
				//Al combinar dos rutas hago el Path Combine
				options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, fileName));
			});
			return services;
		}
	}
}
