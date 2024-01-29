using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Solix.Booking.Application.Configuration;

namespace Solix.Booking.Application
{
	public static class DependencyInjectionServices
	{
		public static IServiceCollection AddApplication(this IServiceCollection services)
		{
			//Configuro el objeto
			var mapper = new MapperConfiguration(config =>
			{
				config.AddProfile(new MapperProfile());
			});

			//Lo creo
			services.AddSingleton(mapper.CreateMapper());

			return services;
		}
	}
}
