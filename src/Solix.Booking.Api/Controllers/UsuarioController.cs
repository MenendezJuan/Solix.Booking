﻿using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Solix.Booking.Application.Database.Usuario.Commands.CreateUser;
using Solix.Booking.Application.Database.Usuarios.Commands.ActualizarPassUsuario;
using Solix.Booking.Application.Database.Usuarios.Commands.ActualizarUsuario;
using Solix.Booking.Application.Database.Usuarios.Commands.CrearUsuario;
using Solix.Booking.Application.Database.Usuarios.Commands.EliminarUsuario;
using Solix.Booking.Application.Database.Usuarios.Queries.GetAllUser;
using Solix.Booking.Application.Database.Usuarios.Queries.GetUserById;
using Solix.Booking.Application.Database.Usuarios.Queries.GetUserByUsernameAndPassword;
using Solix.Booking.Application.Exceptions;
using Solix.Booking.Application.External.ApplicationInsights;
using Solix.Booking.Application.External.GetTokenJWT;
using Solix.Booking.Application.Features;
using Solix.Booking.Common.Constants;
using Solix.Booking.Domain.Models.ApplicationInsights;

namespace Solix.Booking.Api.Controllers
{
//Desactivo los warning que tira al solicitar comentarios en los metodos
#pragma warning disable
	//[AllowAnonymous]
	[Authorize]
	[Route("api/v1/usuario")]
	[ApiController]
	[TypeFilter(typeof(ExceptionManager))]
	public class UsuarioController : ControllerBase
	{
		private readonly IInsertApplicationInsightsService _insertApplicationInsightsService;
		public UsuarioController(IInsertApplicationInsightsService insertApplicationInsightsService)
		{
			_insertApplicationInsightsService = insertApplicationInsightsService;	
		}

		[HttpPost("create")]
		public async Task<IActionResult> CrearUsuario([FromBody] CrearUsuarioDto crearUsuarioDto, [FromServices] ICrearUsuarioCommand crearUsuarioCommand,
			[FromServices] IValidator<CrearUsuarioDto> validator)
		{
			var validate = await validator.ValidateAsync(crearUsuarioDto);

			// Si al menos una de las reglas de validación no se cumple, IsValid será false.
			// Al agregar el "!" (NOT), entraría al bloque de código si IsValid es false, indicando un error de validación.
			if (!validate.IsValid)
				return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, validate.Errors));

			var data = await crearUsuarioCommand.Ejecutar(crearUsuarioDto);

			return StatusCode(StatusCodes.Status201Created, ResponseApiService.Response(StatusCodes.Status201Created, data));
		}

		[HttpPut("update")]
		public async Task<IActionResult> ActualizarUsuario([FromBody] ActualizarUsuarioDto actualizarUsuarioDto, [FromServices] IActualizarUsuarioCommand actualizarUsuarioCommand, [FromServices] IValidator<ActualizarUsuarioDto> validator)
		{
			var validate = await validator.ValidateAsync(actualizarUsuarioDto);

			if (!validate.IsValid)
				return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, validate.Errors));

			var data = await actualizarUsuarioCommand.Ejecutar(actualizarUsuarioDto);
			return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data, "Se actualizo exitosamente"));
		}

		[HttpPut("update-password")]
		public async Task<IActionResult> ActualizarContraseña([FromBody] ActualizarContraseñaUsuarioDto actualizarContraseñaUsuarioDto, [FromServices] IActualizarContraseñaUsuarioCommand actualizarContraseñaUsuarioCommand, [FromServices] IValidator<ActualizarContraseñaUsuarioDto> validator)
		{
			var validate = await validator.ValidateAsync(actualizarContraseñaUsuarioDto);

			if (!validate.IsValid)
				return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, validate.Errors));

			var data = await actualizarContraseñaUsuarioCommand.Ejecutar(actualizarContraseñaUsuarioDto);
			return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data, "Se actualizo la password exitosamente"));
		}

		//Por parametro vamos a tener que recibir un Id de usuario para eliminarlo
		[HttpDelete("delete/{IdUsuario}")]
		public async Task<IActionResult> EliminarUsuario(int IdUsuario, [FromServices] IEliminarUsuarioCommand eliminarUsuarioCommand)
		{
			//Valida que no sea igual a 0
			if (IdUsuario == 0)
			{
				return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest));
			}

			var data = await eliminarUsuarioCommand.Ejecutar(IdUsuario);

			//si no lo encuentra, es decir, devuelve false, va a tirar un statuscode
			if (!data)
			{
				return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));
			}

			return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data, "El usuario fue eliminado exitosamente"));
		}

		//Al ser query va con metodo GET
		[HttpGet("get-all")]
		public async Task<IActionResult> ObtenerTodos([FromServices] IObtenerTodosLosUsuariosQuery obtenerTodosLosUsuarios)
		{
			var metric = new InsertApplicationInsightsModel(
			ApplicationInsightsConstants.METRIC_TYPE_API_CALL,
			EntitiesConstants.USUARIO,
			//Paso todo el detalle de la excepcion a un string
			"get-all");


			_insertApplicationInsightsService.Ejecutar(metric);

			//Dentro del metodo invoco el servicio y guardo el resultado en data
			var data = await obtenerTodosLosUsuarios.Ejecutar();
			if (data == null || data.Count == 0)
			{
				return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));
			}
			return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data, "Se han obtenido los usuarios"));
		}

		[HttpGet("get-by-id/{IdUsuario}")]
		public async Task<IActionResult> ObtenerUsuarioPorId(int IdUsuario, [FromServices] IObtenerUsuarioPorIdQuery obtenerUsuarioPorId)
		{
			var metric = new InsertApplicationInsightsModel(
			ApplicationInsightsConstants.METRIC_TYPE_API_CALL,
			EntitiesConstants.USUARIO,
			//Paso todo el detalle de la excepcion a un string
			"get-by-id");


			_insertApplicationInsightsService.Ejecutar(metric);

			if (IdUsuario == 0)
				return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest));

			var data = await obtenerUsuarioPorId.Ejecutar(IdUsuario);

			//Quizas el Id es valido pero no existe en la Db, tenemos que ver si no es null
			if (data == null)
				return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));

			return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data, $"Se ha obtenido el usuario con Id: {IdUsuario}"));
		}

		[AllowAnonymous]
		[HttpGet("get-by-username-pass/{nombreUsuario}/{password}")]
		public async Task<IActionResult> ObtenerPorNombreUsuarioyPass(string nombreUsuario, string password, [FromServices] IObtenerUsuarioPorNombreYContraseñaQuery porNombreYContraseñaQuery, [FromServices] IValidator<(string, string)> validator,
			[FromServices] IGetTokenJWTService getTokenJWT)
		{
				var metric = new InsertApplicationInsightsModel(
					ApplicationInsightsConstants.METRIC_TYPE_API_CALL,
					EntitiesConstants.USUARIO,
					//Paso todo el detalle de la excepcion a un string
					"get-by-username-pass");


			_insertApplicationInsightsService.Ejecutar(metric);

			var validate = await validator.ValidateAsync((nombreUsuario, password));

			if (!validate.IsValid)
				return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, validate.Errors));

			var data = await porNombreYContraseñaQuery.Ejecutar(nombreUsuario, password);

			if (data == null)
				return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));

			//De esta manera obtengo el token
			data.Token = getTokenJWT.Ejecutar(data.IdUsuario.ToString());

			return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data, "Se ha obtenido el usuario"));
		}
	}
}