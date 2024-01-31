namespace Solix.Booking.Application.Database.Usuarios.Queries.GetUserByUsernameAndPassword
{
	public class ObtenerUsuarioPorNombreYContraseñaDto
	{
		public int IdUsuario { get; set; }
		public string Nombre { get; set; }
		public string Apellido { get; set; }
		public string NombreUsuario { get; set; }
		public string Password { get; set; }

		//Agrego el token
		public string Token { get; set; }
	}
}