namespace Solix.Booking.Application.Database.Clientes.Commands.CrearCliente
{
	public interface ICrearClienteCommand
	{
		Task<CrearClienteDto> Ejecutar(CrearClienteDto modelo);
	}
}