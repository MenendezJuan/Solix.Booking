using Solix.Booking.Domain.Entities.Base;
using Solix.Booking.Domain.Entities.Clientes;
using Solix.Booking.Domain.Entities.Usuarios;

namespace Solix.Booking.Domain.Entities.Reservas
{
    public class Reserva : EntidadBase
	{
		public DateTime RegistrarFecha { get; set; }
		public string CodigoReserva { get; set; }
		public string TipoReserva { get; set; }
		public int IdCliente { get; set; }
		public int IdUsuario { get; set; }

		public Usuario usuario { get; set; }
		public Cliente cliente { get; set; }
	}
}
