using FluentValidation;
using Solix.Booking.Application.Database.Usuarios.Commands.ActualizarUsuario;

namespace Solix.Booking.Application.Validators.Usuario
{
	public class UpdateUsuarioValidator : AbstractValidator<ActualizarUsuarioDto>
	{
		public UpdateUsuarioValidator()
		{
			RuleFor(x => x.IdUsuario)
				.NotNull()
				.GreaterThan(0);
			RuleFor(x => x.Nombre)
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