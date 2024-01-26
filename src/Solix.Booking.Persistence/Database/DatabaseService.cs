using Microsoft.EntityFrameworkCore;
using Solix.Booking.Application.Interfaces;
using Solix.Booking.Domain.Entities.Clientes;
using Solix.Booking.Domain.Entities.Reservas;
using Solix.Booking.Domain.Entities.Usuarios;
using System.Reflection;

namespace Solix.Booking.Persistence.Database
{
	public class DatabaseService : DbContext, IDatabaseService
	{
		/// <summary>
		/// Me va a permitir ingresar o recibir la connection string
		/// </summary>
		/// <param name="options"></param>
		public DatabaseService(DbContextOptions options) : base(options)
		{

		}

		public DbSet<Usuario> usuarios { get; set; }
		public DbSet<Cliente> clientes { get; set; }
		public DbSet<Reserva> reservas { get; set; }

		public async Task<bool> SaveAsync()
		{
			return await SaveChangesAsync() > 0;
		}

		//Esto me mapea directamente las configuraciones realizadas
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		}
	}
}
