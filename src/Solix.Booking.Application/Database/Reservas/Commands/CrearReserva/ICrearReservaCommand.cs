namespace Solix.Booking.Application.Database.Reservas.Commands.CrearReserva
{
	public interface ICrearReservaCommand
	{
		Task<CrearReservaDto> Ejecutar(CrearReservaDto modelo);
	}
}