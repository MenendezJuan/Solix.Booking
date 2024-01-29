namespace Solix.Booking.Application.Database.Clientes.Queries.ObtenerClientesPorId
{
	public interface IObtenerClientePorIdQuery
	{
		Task<ObtenerClientePorIdQuery> Ejecutar(int IdCliente);
	}
}
