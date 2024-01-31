namespace Solix.Booking.Application.Database.Usuario.Commands.CreateUser
{
	public class CrearUsuarioDto
	{
		public string Nombre { get; set; }
		public string Apellido { get; set; }
		public string NombreUsuario { get; set; }
		public string Password { get; set; }
	}
}