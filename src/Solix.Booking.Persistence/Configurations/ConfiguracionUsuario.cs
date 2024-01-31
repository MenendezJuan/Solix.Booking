using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Solix.Booking.Domain.Entities.Usuarios;

namespace Solix.Booking.Persistence.Configurations
{
	public class ConfiguracionUsuario
	{
		//ctor - para crear constructor
		public ConfiguracionUsuario(EntityTypeBuilder<Usuario> entityBuilder)
		{
			//Lo marco como llave primaria
			entityBuilder.HasKey(x => x.IdUsuario);

			//Marco como propiedad y requerida
			entityBuilder.Property(x => x.Nombre).IsRequired();

			entityBuilder.Property(x => x.Apellido).IsRequired();

			entityBuilder.Property(x => x.NombreUsuario).IsRequired();

			entityBuilder.Property(x => x.Password).IsRequired();

			//Digo que un usuario tiene muchas reservas y la FK
			entityBuilder.HasMany(x => x.reserva)
				.WithOne(x => x.usuario)
				//La que relaciona
				.HasForeignKey(x => x.IdUsuario);
		}
	}
}