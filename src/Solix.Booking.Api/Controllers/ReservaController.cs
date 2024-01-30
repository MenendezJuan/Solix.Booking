using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Solix.Booking.Application.Database.Reservas.Commands.CrearReserva;
using Solix.Booking.Application.Database.Reservas.Queries.ObtenerReservasPorNroDocumento;
using Solix.Booking.Application.Database.Reservas.Queries.ObtenerReservasPorTipo;
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
		public async Task<IActionResult> CrearReserva([FromBody] CrearReservaDto reservaDto, [FromServices] ICrearReservaCommand crearReservaCommand, [FromServices] IValidator<CrearReservaDto> validator)
		{
			var validate = await validator.ValidateAsync(reservaDto);

			if(!validate.IsValid)
				return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, validate.Errors));

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

		//Esta es otra forma de hacer nuestra api, pasamos por parametro y no por la ruta como habiamos hecho
		[HttpGet("get-by-documentNumber")]
		//En este caso sera FromQuery, dado que no usamos el automapper para este metodo
		public async Task<IActionResult> ObtenerPorNroDocumento([FromQuery] string numeroDocumento, [FromServices] IObtenerReservasPorNroDocumentoQuery obtenerReservasPorNroDocumento)
		{
			//valido si el string esta vacio o no
			if (string.IsNullOrEmpty(numeroDocumento))
				return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest));

			//Obtengo el resultado de la db
			var data = await obtenerReservasPorNroDocumento.Ejecutar(numeroDocumento);

			if (data == null)
				return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));

			return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data, $"Se obtuvo la reserva del cliente con nro de documento: {numeroDocumento}"));
		}

		[HttpGet("get-by-type")]
		//En este caso sera FromQuery, dado que no usamos el automapper para este metodo
		public async Task<IActionResult> ObtenerPorTipo([FromQuery] string tipoReserva, [FromServices] IObtenerReservasPorTipoQuery obtenerReservasPorTipo)
		{
			//valido si el string esta vacio o no
			if (string.IsNullOrEmpty(tipoReserva))
				return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest));

			//Invocamos servicio y lo guardamos el resultado en data
			var data = await obtenerReservasPorTipo.Ejecutar(tipoReserva);

			//Valido si data trae contenido o no
			if (data == null)
				return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));

			//En caso de exito
			return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data, $"Se obtuvo la reserva del cliente con tipo de reserva: {tipoReserva}"));
		}

	}
}
