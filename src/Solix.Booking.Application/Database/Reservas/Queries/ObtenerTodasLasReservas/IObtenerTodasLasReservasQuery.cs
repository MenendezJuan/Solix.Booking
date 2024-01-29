namespace Solix.Booking.Application.Database.Reservas.Queries.ObtenerTodasLasReservas
{
	public interface IObtenerTodasLasReservasQuery
	{
		Task<List<ObtenerTodasLasReservasDto>> Ejecutar();
	}
}
