namespace Solix.Booking.Application.Database.Usuarios.Commands.ActualizarUsuario
{
	public interface IActualizarUsuarioCommand
	{
		Task<ActualizarUsuarioDto> Execute(ActualizarUsuarioDto modelo);
	}
}
