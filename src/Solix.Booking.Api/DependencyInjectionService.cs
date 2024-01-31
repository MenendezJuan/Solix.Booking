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
				//Integrar token de autorizacion con swagger
				options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
				{
					In = ParameterLocation.Header,
					Description = "Ingrese un token valido",
					Name = "Authorization",
					Type = SecuritySchemeType.Http, 
					BearerFormat = "JWT",
					Scheme = "Bearer"
				});

				//Lo que necesitan las APIs para ejecutarse correctamente
				options.AddSecurityRequirement(new OpenApiSecurityRequirement
				{
					{
						new OpenApiSecurityScheme
						{
							Reference = new OpenApiReference
							{
								Type = ReferenceType.SecurityScheme,
								Id = "Bearer"
							}
						},
						new string[]{}
					}
				});

				var fileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
				//Al combinar dos rutas hago el Path Combine
				options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, fileName));
			});
			return services;
		}
	}
}
