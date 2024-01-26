using Solix.Booking.Domain.Entities.Base;
using Solix.Booking.Domain.Entities.Reservas;

namespace Solix.Booking.Domain.Entities.Usuarios
{
    public class Usuario : EntidadBase
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NombreUsuario { get; set; }
        public string Password { get; set; }

        //Un usuario puede crear muchas reservas
        public ICollection<Reserva> reservas { get; set; }
    }
}
