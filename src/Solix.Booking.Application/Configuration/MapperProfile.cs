using AutoMapper;
using Solix.Booking.Application.Database.Usuario.Commands.CreateUser;
using Solix.Booking.Domain.Entities.Usuarios;

namespace Solix.Booking.Application.Configuration
{
	public class MapperProfile : Profile
	{
		//Cuando se necesite mapear lo haremos dentro del constructor
		public MapperProfile()
		{
			CreateMap<Usuario,CrearUsuarioDto>().ReverseMap();
		}
	}
}
