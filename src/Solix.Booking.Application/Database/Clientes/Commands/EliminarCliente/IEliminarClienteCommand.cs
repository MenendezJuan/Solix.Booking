namespace Solix.Booking.Application.Database.Clientes.Commands.EliminarCliente
{
	public interface IEliminarClienteCommand
	{
		Task<bool> Ejecutar(int IdCliente);
	}
}