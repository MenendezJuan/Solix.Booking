namespace Solix.Booking.Application.Database.Reservas.Queries.ObtenerReservasPorNroDocumento
{
	public interface IObtenerReservasPorNroDocumentoQuery
	{
		Task<List<ObtenerReservasPorNroDocumentoDto>> Ejecutar(string nroDocumento);
	}
}