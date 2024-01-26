using Solix.Booking.Domain.Entities.Reservas;

namespace Solix.Booking.Domain.Entities.Clientes
{
	public class Cliente
	{
		public Cliente()
		{
			reserva = new HashSet<Reserva>();
		}
		public int IdCliente { get; set; }
		public string NombreCompleto { get; set; }
		public string Documento { get; set; }

		//Un cliente puede generar muchas reservas
		public ICollection<Reserva> reserva { get; set; }
	}
}
