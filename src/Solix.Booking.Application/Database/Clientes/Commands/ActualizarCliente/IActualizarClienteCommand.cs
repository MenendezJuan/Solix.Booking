namespace Solix.Booking.Application.Database.Clientes.Commands.ActualizarCliente
{
	public interface IActualizarClienteCommand
	{
		Task<ActualizarClienteDto> Ejecutar(ActualizarClienteDto modelo);
	}
}
