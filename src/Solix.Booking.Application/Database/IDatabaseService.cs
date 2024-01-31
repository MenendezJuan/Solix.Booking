using Microsoft.EntityFrameworkCore;
using Solix.Booking.Domain.Entities.Clientes;
using Solix.Booking.Domain.Entities.Reservas;
using Solix.Booking.Domain.Entities.Usuarios;

namespace Solix.Booking.Application.Interfaces
{
	public interface IDatabaseService
	{
		DbSet<Usuario> usuario { get; set; }

		DbSet<Cliente> cliente { get; set; }
		DbSet<Reserva> reserva { get; set; }

		Task<bool> SaveAsync();
	}
}