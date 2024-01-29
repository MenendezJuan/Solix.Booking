namespace Solix.Booking.Application.Database.Reservas.Queries.ObtenerReservasPorTipo
{
	public class ObtenerReservasPorTipoDto
	{
		public DateTime RegistrarFecha { get; set; }
		public string CodigoReserva { get; set; }
		public string TipoReserva { get; set; }
		public string NombreCompletoCliente { get; set; }
		public string DocumentoCliente { get; set; }
	}
}
