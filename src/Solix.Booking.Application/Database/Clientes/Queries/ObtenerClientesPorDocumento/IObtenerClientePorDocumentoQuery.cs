namespace Solix.Booking.Application.Database.Clientes.Queries.ObtenerClientesPorDocumento
{
	public interface IObtenerClientePorDocumentoQuery
	{
		Task<ObtenerClientePorDocumentoDto> Ejecutar(string documento);
	}
}