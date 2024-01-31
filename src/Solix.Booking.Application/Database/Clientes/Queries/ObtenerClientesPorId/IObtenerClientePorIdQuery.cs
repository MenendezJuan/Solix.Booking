namespace Solix.Booking.Application.Database.Clientes.Queries.ObtenerClientesPorId
{
	public interface IObtenerClientePorIdQuery
	{
		Task<ObtenerClientePorIdDto> Ejecutar(int IdCliente);
	}
}