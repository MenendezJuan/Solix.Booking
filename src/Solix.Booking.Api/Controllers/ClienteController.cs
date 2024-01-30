using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Solix.Booking.Application.Database.Clientes.Commands.ActualizarCliente;
using Solix.Booking.Application.Database.Clientes.Commands.CrearCliente;
using Solix.Booking.Application.Database.Clientes.Commands.EliminarCliente;
using Solix.Booking.Application.Database.Clientes.Queries.ObtenerClientesPorDocumento;
using Solix.Booking.Application.Database.Clientes.Queries.ObtenerClientesPorId;
using Solix.Booking.Application.Database.Clientes.Queries.ObtenerTodosLosClientes;
using Solix.Booking.Application.Exceptions;
using Solix.Booking.Application.Features;
using System.ComponentModel.DataAnnotations;

namespace Solix.Booking.Api.Controllers
{
	[Route("api/v1/cliente")]
	[ApiController]
	[TypeFilter(typeof(ExceptionManager))]

	public class ClienteController : ControllerBase
	{

		[HttpPost("create")]
		public async Task<IActionResult> CrearCliente([FromBody] CrearClienteDto clienteDto, [FromServices]ICrearClienteCommand crearClienteCommand, [FromServices] IValidator<CrearClienteDto> validator)
		{
			var validate = await validator.ValidateAsync(clienteDto);

			//Solo ingresa cuando sea false
			if (!validate.IsValid)
			{
				return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, validate.Errors));
			}

			var data = await crearClienteCommand.Ejecutar(clienteDto);

			return StatusCode(StatusCodes.Status201Created, ResponseApiService.Response(StatusCodes.Status201Created, data));
		}

		[HttpPut("update")]
		public async Task<IActionResult> ActualizarCliente([FromBody] ActualizarClienteDto clienteDto, [FromServices] IActualizarClienteCommand actualizarClienteCommand, [FromServices] IValidator<ActualizarClienteDto> validator)
		{
			var validate = await validator.ValidateAsync(clienteDto);

			//Solo ingresa cuando sea false
			if (!validate.IsValid)
			{
				return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, validate.Errors));
			}
			var data = await actualizarClienteCommand.Ejecutar(clienteDto);
			return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data, "Cliente actualizado"));
		}

		[HttpDelete("delete/{IdCliente}")]
		public async Task<IActionResult> EliminarCliente(int IdCliente, [FromServices] IEliminarClienteCommand eliminarClienteCommand)
		{
			if(IdCliente == 0)
				return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest));

			var data = await eliminarClienteCommand.Ejecutar(IdCliente);

			if (!data)
				return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));

			return StatusCode(StatusCodes.Status200OK,ResponseApiService.Response(StatusCodes.Status200OK,data, "El cliente fue eliminado correctamente"));
		}

		[HttpGet("get-all")]
		public async Task<IActionResult> ObtenerTodos([FromServices] IObtenerTodosLosClientesQuery clientesQuery)
		{
			var data = await clientesQuery.Ejecutar();

			if(data==null || data.Count == 0)
			{
				return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));
			}
			return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data, "Se han obtenido todos los clientes"));
		}

		[HttpGet("get-by-id/{IdCliente}")]
		public async Task<IActionResult> ObtenerPorId(int IdCliente,[FromServices] IObtenerClientePorIdQuery obtenerClientePorIdQuery)
		{
			if(IdCliente == 0)
				return StatusCode(StatusCodes.Status400BadRequest,ResponseApiService.Response(StatusCodes.Status400BadRequest));

			var data = await obtenerClientePorIdQuery.Ejecutar(IdCliente);

			if (data == null)
				return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));

			return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data, $"Se obtuvo el cliente con ID: {IdCliente}"));
		}

		[HttpGet("get-by-document/{numeroDocumento}")]
		public async Task<IActionResult> ObtenerPorNroDocumento(string numeroDocumento, [FromServices] IObtenerClientePorDocumentoQuery clientePorDocumentoQuery)
		{
			//valido si el string esta vacio o no
			if(string.IsNullOrEmpty(numeroDocumento))
				return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest));

			//Obtengo el resultado de la db
			var data = await clientePorDocumentoQuery.Ejecutar(numeroDocumento);

			if (data == null)
				return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));

			return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data, $"Se obtuvo el cliente con nro de documento: {numeroDocumento}"));
		}

	}
}
