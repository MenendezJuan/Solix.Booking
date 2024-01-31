namespace Solix.Booking.Application.Database.Usuarios.Queries.GetUserById
{
	public class ObtenerUsuarioPorIdDto
	{
		public int IdUsuario { get; set; }
		public string Nombre { get; set; }
		public string Apellido { get; set; }
		public string NombreUsuario { get; set; }
		public string Password { get; set; }
	}
}