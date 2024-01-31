namespace Solix.Booking.Application.Database.Usuarios.Queries.GetUserByUsernameAndPassword
{
	public interface IObtenerUsuarioPorNombreYContraseñaQuery
	{
		Task<ObtenerUsuarioPorNombreYContraseñaDto> Ejecutar(string nombreUsuario, string password);
	}
}