namespace Solix.Booking.Application.Database.Usuarios.Commands.ActualizarUsuario
{
	public class ActualizarUsuarioDto
	{
		public int IdUsuario { get; set; }
		public string Nombre { get; set; }
		public string Apellido { get; set; }
		public string NombreUsuario { get; set; }
		public string Password { get; set; }
	}
}