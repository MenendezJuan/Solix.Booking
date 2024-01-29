namespace Solix.Booking.Application.Database.Usuarios.Commands.EliminarUsuario
{
	public interface IEliminarUsuarioCommand
	{
		Task<bool> Ejecutar(int IdUsuario);
	}
}
