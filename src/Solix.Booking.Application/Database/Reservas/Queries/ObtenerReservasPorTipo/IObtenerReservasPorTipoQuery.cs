namespace Solix.Booking.Application.Database.Reservas.Queries.ObtenerReservasPorTipo
{
	public interface IObtenerReservasPorTipoQuery
	{
		Task<List<ObtenerReservasPorTipoDto>> Ejecutar(string tipo);
	}
}