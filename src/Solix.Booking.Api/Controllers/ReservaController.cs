using Microsoft.AspNetCore.Mvc;
using Solix.Booking.Application.Database.Clientes.Queries.ObtenerTodosLosClientes;
using Solix.Booking.Application.Database.Reservas.Commands.CrearReserva;
using Solix.Booking.Application.Database.Reservas.Queries.ObtenerTodasLasReservas;
using Solix.Booking.Application.Exceptions;
using Solix.Booking.Application.Features;

namespace Solix.Booking.Api.Controllers
{
	[Route("api/v1/reserva")]
	[ApiController]
	[TypeFilter(typeof(ExceptionManager))]

	public class ReservaController : ControllerBase
	{
		[HttpPost("create")]
		public async Task<IActionResult> CrearReserva([FromBody] CrearReservaDto reservaDto, [FromServices] ICrearReservaCommand crearReservaCommand)
		{
			var data = await crearReservaCommand.Ejecutar(reservaDto);

			return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data, "Se creo la reserva correctamente"));
		}

		[HttpGet("get-all")]
		public async Task<IActionResult> ObtenerTodos([FromServices] IObtenerTodasLasReservasQuery reservasQuery)
		{
			var data = await reservasQuery.Ejecutar();

			if (data == null || data.Count == 0)
			{
				return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));
			}
			return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data, "Se han obtenido todas las reservas"));
		}
	}
}
