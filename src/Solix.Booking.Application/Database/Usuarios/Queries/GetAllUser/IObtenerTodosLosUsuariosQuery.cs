namespace Solix.Booking.Application.Database.Usuarios.Queries.GetAllUser
{
	public interface IObtenerTodosLosUsuariosQuery
	{
		Task<List<ObtenerTodosLosUsuariosDto>> Ejecutar();
	}
}
