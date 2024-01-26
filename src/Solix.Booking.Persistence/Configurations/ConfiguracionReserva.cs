using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Solix.Booking.Domain.Entities.Reservas;

namespace Solix.Booking.Persistence.Configurations
{
	public class ConfiguracionReserva
	{
		public ConfiguracionReserva(EntityTypeBuilder<Reserva> entityBuilder)
		{
			entityBuilder.HasKey(x => x.Id);

			entityBuilder.Property(x => x.RegistrarFecha).IsRequired();
			entityBuilder.Property(x => x.CodigoReserva).IsRequired();
			entityBuilder.Property(x => x.TipoReserva).IsRequired();

			entityBuilder.Property(x => x.IdUsuario).IsRequired();
			entityBuilder.Property(x => x.IdCliente).IsRequired();

			//Relaciono con la tabla usuarios
			entityBuilder.HasOne(x => x.usuario)
				.WithMany(x => x.reservas)
				.HasForeignKey(x => x.IdUsuario);

			//Relaciono con la tabla clientes 
			entityBuilder.HasOne(x=>x.cliente)
				.WithMany(x=>x.reservas)
				.HasForeignKey(x=>x.IdCliente);

		}
	}
}
