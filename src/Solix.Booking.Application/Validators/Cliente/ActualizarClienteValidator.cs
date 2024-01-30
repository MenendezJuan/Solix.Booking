using FluentValidation;
using Solix.Booking.Application.Database.Clientes.Commands.ActualizarCliente;

namespace Solix.Booking.Application.Validators.Cliente
{
	public class ActualizarClienteValidator : AbstractValidator<ActualizarClienteDto>
	{
		public ActualizarClienteValidator()
		{
			RuleFor(x => x.IdCliente)
				.NotNull()
				.GreaterThan(0);

			RuleFor(x => x.NombreCompleto)
				.NotNull()
				.NotEmpty()
				.MaximumLength(50);
			
			RuleFor(x => x.Documento)
				.NotNull()
				.NotEmpty()
				.Length(8);
		}
	}
}
