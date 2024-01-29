namespace Solix.Booking.Application.Database.Clientes.Queries.ObtenerClientesPorDocumento
{
	public interface IObtenerClientePorDocumentoQuery
	{ 
		Task<ObtenerClientePorDocumentoQuery> Ejecutar(string documento);
	}
}
