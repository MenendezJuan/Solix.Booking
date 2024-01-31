using Solix.Booking.Application.Database.Usuario.Commands.CreateUser;

namespace Solix.Booking.Application.Database.Usuarios.Commands.CrearUsuario
{
	public interface ICrearUsuarioCommand
	{
		Task<CrearUsuarioDto> Ejecutar(CrearUsuarioDto modelo);
	}
}