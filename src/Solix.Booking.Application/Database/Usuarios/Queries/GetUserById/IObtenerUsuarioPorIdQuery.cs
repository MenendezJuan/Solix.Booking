namespace Solix.Booking.Application.Database.Usuarios.Queries.GetUserById
{
	public interface IObtenerUsuarioPorIdQuery
	{
		Task<ObtenerUsuarioPorIdDto> Ejecutar(int IdUsuario);
	}
}
