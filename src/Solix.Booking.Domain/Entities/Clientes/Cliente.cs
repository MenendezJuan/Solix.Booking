using Solix.Booking.Domain.Entities.Base;
using Solix.Booking.Domain.Entities.Reservas;

namespace Solix.Booking.Domain.Entities.Clientes
{
    public class Cliente : EntidadBase
    {
        public string NombreCompleto { get; set; }
        public string Documento { get; set; }

        //Un cliente puede generar muchas reservas
        public ICollection<Reserva> reservas { get; set; }
    }
}
