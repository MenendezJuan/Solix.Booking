namespace Solix.Booking.Domain.Entities
{
	public class Usuario : EntidadBase
	{
		public string Nombre { get; set; }
		public string Apellido { get; set; }
		public string NombreUsuario { get; set; }
		public string Password { get; set; }
	}
}
