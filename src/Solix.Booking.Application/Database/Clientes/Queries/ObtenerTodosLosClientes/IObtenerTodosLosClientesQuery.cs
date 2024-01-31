namespace Solix.Booking.Application.Database.Clientes.Queries.ObtenerTodosLosClientes
{
	public interface IObtenerTodosLosClientesQuery
	{
		Task<List<ObtenerTodosLosClientesDto>> Ejecutar();
	}
}