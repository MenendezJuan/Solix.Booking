using Microsoft.EntityFrameworkCore;
using Solix.Booking.Application.Interfaces;
using Solix.Booking.Domain.Entities.Clientes;
using Solix.Booking.Domain.Entities.Reservas;
using Solix.Booking.Domain.Entities.Usuarios;
using Solix.Booking.Persistence.Configurations;

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

		public virtual DbSet<Usuario> usuario { get; set; }
		public virtual DbSet<Cliente> cliente { get; set; }
		public virtual DbSet<Reserva> reserva { get; set; }

		public async Task<bool> SaveAsync()
		{
			return await SaveChangesAsync() > 0;
		}

		//Esto me mapea directamente las configuraciones realizadas
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			EntityConfiguration(modelBuilder);
		}

		private void EntityConfiguration(ModelBuilder modelBuilder)
		{
			new ConfiguracionUsuario(modelBuilder.Entity<Usuario>());
			new ConfiguracionCliente(modelBuilder.Entity<Cliente>());
			new ConfiguracionReserva(modelBuilder.Entity<Reserva>());
		}


	}
}
