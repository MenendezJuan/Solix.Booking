using FluentValidation;

namespace Solix.Booking.Application.Validators.Usuario
{
	//Para poder validar esos campos, directamente paso el tipo, no el nombre de la variable
	public class ObtenerUsuarioPorNombreYContraseñaValidator : AbstractValidator<(string, string)>
	{
        public ObtenerUsuarioPorNombreYContraseñaValidator()
        {
            //Este seria UserName (item1)
            RuleFor(x => x.Item1)
                .NotNull()
                .NotEmpty()
                .MaximumLength(50);
			//Esta seria la Password (item 2)
			RuleFor(x => x.Item2)
				.NotNull()
				.NotEmpty()
				.MaximumLength(10);
		}
    }
}
