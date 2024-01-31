using FluentValidation;
using Solix.Booking.Application.Database.Usuarios.Commands.ActualizarPassUsuario;

namespace Solix.Booking.Application.Validators.Usuario
{
	public class ActualizarPassUsuarioValidator : AbstractValidator<ActualizarContraseñaUsuarioDto>
	{
		public ActualizarPassUsuarioValidator()
		{
			RuleFor(x => x.IdUsuario)
				.NotNull()
				.GreaterThan(0);
			RuleFor(x => x.Password)
				.NotNull()
				.NotEmpty()
				.MaximumLength(10);
		}
	}
}