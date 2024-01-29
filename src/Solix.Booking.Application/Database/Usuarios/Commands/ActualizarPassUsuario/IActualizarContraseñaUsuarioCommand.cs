namespace Solix.Booking.Application.Database.Usuarios.Commands.ActualizarPassUsuario
{
	public interface IActualizarContraseñaUsuarioCommand
	{
		Task<bool> Ejecutar(ActualizarContraseñaUsuarioDto modelo);
	}
}
