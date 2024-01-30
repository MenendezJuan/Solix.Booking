using FluentValidation;
using Solix.Booking.Application.Database.Usuario.Commands.CreateUser;

namespace Solix.Booking.Application.Validators.Usuario
{
	public class CrearValidatorUsuario : AbstractValidator<CrearUsuarioDto>
	{
		public CrearValidatorUsuario()
		{
			RuleFor(x=>x.Nombre)
				.NotNull()
				.WithMessage("El campo no puede ser nulo")
					.NotEmpty().WithMessage("El campo no puede ser vacio")
					.MaximumLength(50).WithMessage("El campo no puede ser mayor a 50 caracteres");
			RuleFor(x => x.Apellido)
				.NotNull()
				.NotEmpty()
				.MaximumLength(50);
			RuleFor(x => x.NombreUsuario)
				.NotNull()
				.NotEmpty()
				.MaximumLength(50);
			RuleFor(x => x.Password)
				.NotNull()
				.NotEmpty()
				.MaximumLength(10);
		}
	}
}
