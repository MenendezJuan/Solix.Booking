using AutoMapper;
using Solix.Booking.Application.Database.Clientes.Commands.ActualizarCliente;
using Solix.Booking.Application.Database.Clientes.Commands.CrearCliente;
using Solix.Booking.Application.Database.Clientes.Queries.ObtenerClientesPorDocumento;
using Solix.Booking.Application.Database.Clientes.Queries.ObtenerClientesPorId;
using Solix.Booking.Application.Database.Clientes.Queries.ObtenerTodosLosClientes;
using Solix.Booking.Application.Database.Usuario.Commands.CreateUser;
using Solix.Booking.Application.Database.Usuarios.Commands.ActualizarUsuario;
using Solix.Booking.Application.Database.Usuarios.Queries.GetAllUser;
using Solix.Booking.Application.Database.Usuarios.Queries.GetUserById;
using Solix.Booking.Application.Database.Usuarios.Queries.GetUserByUsernameAndPassword;
using Solix.Booking.Domain.Entities.Clientes;
using Solix.Booking.Domain.Entities.Usuarios;

namespace Solix.Booking.Application.Configuration
{
	public class MapperProfile : Profile
	{
		//Cuando se necesite mapear lo haremos dentro del constructor
		public MapperProfile()
		{
			#region Usuario
			CreateMap<Usuario,CrearUsuarioDto>().ReverseMap();
			CreateMap<Usuario,ActualizarUsuarioDto>().ReverseMap();
			CreateMap<Usuario,ObtenerTodosLosUsuariosDto>().ReverseMap();
			CreateMap<Usuario,ObtenerUsuarioPorIdDto>().ReverseMap();
			CreateMap<Usuario,ObtenerUsuarioPorNombreYContraseñaDto>().ReverseMap();
			#endregion
			#region Cliente
			CreateMap<Cliente,CrearClienteDto>().ReverseMap();
			CreateMap<Cliente, ActualizarClienteDto>().ReverseMap();
			CreateMap<Cliente, ObtenerTodosLosClientesDto>().ReverseMap();
			CreateMap<Cliente, ObtenerClientePorIdDto>().ReverseMap();
			CreateMap<Cliente, ObtenerClientePorDocumentoDto>().ReverseMap();
			#endregion
		}
	}
}
