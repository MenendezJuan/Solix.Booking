using FluentValidation;
using Solix.Booking.Application.Database.Reservas.Commands.CrearReserva;

namespace Solix.Booking.Application.Validators.Reserva
{
	public class CrearValidatorReserva : AbstractValidator<CrearReservaDto>
	{
		public CrearValidatorReserva()
		{
			RuleFor(x => x.CodigoReserva)
				.NotNull()
				.NotEmpty()
				.Length(8);
			RuleFor(x => x.TipoReserva)
				.NotNull()
				.NotEmpty()
				.Length(50);
			RuleFor(x => x.IdCliente)
				.NotNull()
				.GreaterThan(0);
			RuleFor(x => x.IdUsuario)
				.NotNull()
				.GreaterThan(0);
		}
	}
}