﻿using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Solix.Booking.Application.Configuration;
using Solix.Booking.Application.Database.Clientes.Commands.ActualizarCliente;
using Solix.Booking.Application.Database.Clientes.Commands.CrearCliente;
using Solix.Booking.Application.Database.Clientes.Commands.EliminarCliente;
using Solix.Booking.Application.Database.Clientes.Queries.ObtenerClientesPorDocumento;
using Solix.Booking.Application.Database.Clientes.Queries.ObtenerClientesPorId;
using Solix.Booking.Application.Database.Clientes.Queries.ObtenerTodosLosClientes;
using Solix.Booking.Application.Database.Reservas.Commands.CrearReserva;
using Solix.Booking.Application.Database.Reservas.Queries.ObtenerReservasPorNroDocumento;
using Solix.Booking.Application.Database.Reservas.Queries.ObtenerReservasPorTipo;
using Solix.Booking.Application.Database.Reservas.Queries.ObtenerTodasLasReservas;
using Solix.Booking.Application.Database.Usuarios.Commands.ActualizarPassUsuario;
using Solix.Booking.Application.Database.Usuarios.Commands.ActualizarUsuario;
using Solix.Booking.Application.Database.Usuarios.Commands.CrearUsuario;
using Solix.Booking.Application.Database.Usuarios.Commands.CreateUser;
using Solix.Booking.Application.Database.Usuarios.Commands.EliminarUsuario;
using Solix.Booking.Application.Database.Usuarios.Queries.GetAllUser;
using Solix.Booking.Application.Database.Usuarios.Queries.GetUserById;
using Solix.Booking.Application.Database.Usuarios.Queries.GetUserByUsernameAndPassword;

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
			//Registro servicios
			#region ServicioUsuario
			services.AddTransient<ICrearUsuarioCommand, CrearUsuarioCommand>();
			services.AddTransient<IActualizarUsuarioCommand, ActualizarUsuarioCommand>();
			services.AddTransient<IEliminarUsuarioCommand, EliminarUsuarioCommand>();
			services.AddTransient<IActualizarContraseñaUsuarioCommand, ActualizarContraseñaUsuarioCommand>();
			services.AddTransient<IObtenerTodosLosUsuariosQuery, ObtenerTodosLosUsuariosQuery>();
			services.AddTransient<IObtenerUsuarioPorIdQuery, ObtenerUsuarioPorIdQuery>();
			services.AddTransient<IObtenerUsuarioPorNombreYContraseñaQuery ,ObtenerUsuarioPorNombreYContraseñaQuery>();
			#endregion
			#region ServicioCliente
			services.AddTransient<ICrearClienteCommand, CrearClienteCommand>();
			services.AddTransient<IActualizarClienteCommand, ActualizarClienteCommand>();
			services.AddTransient<IEliminarClienteCommand, EliminarClienteCommand>();
			services.AddTransient<IObtenerTodosLosClientesQuery, ObtenerTodosLosClientesQuery>();
			services.AddTransient<IObtenerClientePorIdQuery, ObtenerClientePorIdQuery>();
			services.AddTransient<IObtenerClientePorDocumentoQuery, ObtenerClientePorDocumentoQuery>();

			#endregion

			#region ServicioReserva
			services.AddTransient<ICrearReservaCommand, CrearReservaCommand>();
			services.AddTransient<IObtenerTodasLasReservasQuery, ObtenerTodasLasReservasQuery>();
			services.AddTransient<IObtenerReservasPorNroDocumentoQuery, ObtenerReservasPorNroDocumentoQuery>();
			services.AddTransient<IObtenerReservasPorTipoQuery, ObtenerReservasPorTipoQuery>();

			#endregion
			return services;
		}
	}
}
