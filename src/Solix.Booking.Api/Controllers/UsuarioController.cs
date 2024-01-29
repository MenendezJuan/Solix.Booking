using Microsoft.AspNetCore.Mvc;
using Solix.Booking.Application.Features;

namespace Solix.Booking.Api.Controllers
{
	[Route("api/v1/usuario")]
	[ApiController]
	public class UsuarioController : ControllerBase
	{
		public UsuarioController()
		{
			
		}

		//Decoradores
		[HttpPost]
		public async Task<IActionResult> test()
		{
			return StatusCode(StatusCodes.Status200OK,
				ResponseApiService.Response(StatusCodes.Status200OK, "{}", "Ejecucion Exitosa"));
		}
	}
}
