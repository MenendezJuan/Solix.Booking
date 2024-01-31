namespace Solix.Booking.Application.Database.Reservas.Queries.ObtenerTodasLasReservas
{
	public class ObtenerTodasLasReservasDto
	{
		public int IdReserva { get; set; }
		public DateTime RegistrarFecha { get; set; }
		public string CodigoReserva { get; set; }
		public string TipoReserva { get; set; }

		//Personalizo el DTO
		public string ClienteNombre { get; set; }

		public string DocumentoCliente { get; set; }
	}
}