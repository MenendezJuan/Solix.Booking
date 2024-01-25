namespace Solix.Booking.Domain.Entities.Reserva
{
	public class Reservas : EntidadBase
	{
		public DateTime RegistrarFecha { get; set; }
		public string CodigoReserva { get; set; }
		public string TipoReserva { get; set; }
		public int IdCliente { get; set; }
		public int IdUsuario { get; set; }
	}
}
