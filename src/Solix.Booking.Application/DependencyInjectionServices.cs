using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Solix.Booking.Application.Configuration;
using Solix.Booking.Application.Database.Usuarios.Commands.ActualizarPassUsuario;
using Solix.Booking.Application.Database.Usuarios.Commands.ActualizarUsuario;
using Solix.Booking.Application.Database.Usuarios.Commands.CrearUsuario;
using Solix.Booking.Application.Database.Usuarios.Commands.CreateUser;
using Solix.Booking.Application.Database.Usuarios.Commands.EliminarUsuario;

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
			services.AddTransient<ICrearUsuarioCommand, CrearUsuarioCommand>();
			services.AddTransient<IActualizarUsuarioCommand, ActualizarUsuarioCommand>();
			services.AddTransient<IEliminarUsuarioCommand, EliminarUsuarioCommand>();
			services.AddTransient<IActualizarContraseñaUsuarioCommand, ActualizarContraseñaUsuarioCommand>();
			return services;
		}
	}
}
