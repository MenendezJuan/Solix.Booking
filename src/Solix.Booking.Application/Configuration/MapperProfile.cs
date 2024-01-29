﻿using AutoMapper;
using Solix.Booking.Application.Database.Usuario.Commands.CreateUser;
using Solix.Booking.Application.Database.Usuarios.Commands.ActualizarUsuario;
using Solix.Booking.Application.Database.Usuarios.Queries.GetAllUser;
using Solix.Booking.Application.Database.Usuarios.Queries.GetUserById;
using Solix.Booking.Application.Database.Usuarios.Queries.GetUserByUsernameAndPassword;
using Solix.Booking.Domain.Entities.Usuarios;

namespace Solix.Booking.Application.Configuration
{
	public class MapperProfile : Profile
	{
		//Cuando se necesite mapear lo haremos dentro del constructor
		public MapperProfile()
		{
			CreateMap<Usuario,CrearUsuarioDto>().ReverseMap();
			CreateMap<Usuario,ActualizarUsuarioDto>().ReverseMap();
			CreateMap<Usuario,ObtenerTodosLosUsuariosDto>().ReverseMap();
			CreateMap<Usuario,ObtenerUsuarioPorIdDto>().ReverseMap();
			CreateMap<Usuario,ObtenerUsuarioPorNombreYContraseñaDto>().ReverseMap();
		}
	}
}
