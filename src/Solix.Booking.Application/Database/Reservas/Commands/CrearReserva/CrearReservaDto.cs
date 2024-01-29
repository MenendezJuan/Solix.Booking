namespace Solix.Booking.Application.Database.Reservas.Commands.CrearReserva
{
	public class CrearReservaDto
	{
		public DateTime RegistrarFecha { get; set; }
		public string CodigoReserva { get; set; }
		public string TipoReserva { get; set; }
		public int IdCliente { get; set; }
		public int IdUsuario { get; set; }

	}
}
