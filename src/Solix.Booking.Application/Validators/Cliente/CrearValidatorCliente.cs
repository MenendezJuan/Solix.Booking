using FluentValidation;
using Solix.Booking.Application.Database.Clientes.Commands.CrearCliente;

namespace Solix.Booking.Application.Validators.Cliente
{
	public class CrearValidatorCliente : AbstractValidator<CrearClienteDto>
	{
		public CrearValidatorCliente()
		{
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