using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Solix.Booking.Domain.Entities.Clientes;

namespace Solix.Booking.Persistence.Configurations
{
	public class ConfiguracionCliente
	{
		public ConfiguracionCliente(EntityTypeBuilder<Cliente> entityBuilder)
		{
			entityBuilder.HasKey(c => c.IdCliente);

			entityBuilder.Property(c => c.NombreCompleto).IsRequired();

			entityBuilder.Property(c => c.Documento).IsRequired();

			entityBuilder.HasMany(x => x.reserva)
				.WithOne(x => x.cliente)
				.HasForeignKey(x => x.IdCliente);
		}
	}
}