using Microsoft.EntityFrameworkCore;
using Solix.Booking.Domain.Entities.Clientes;
using Solix.Booking.Domain.Entities.Reservas;
using Solix.Booking.Domain.Entities.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solix.Booking.Application.Interfaces
{
	public interface IDatabaseService
	{
		DbSet<Usuario> usuarios { get; set; }

		DbSet<Cliente> clientes { get; set; }
		DbSet<Reserva> reservas { get; set; }
		Task<bool> SaveAsync();

	}
}
