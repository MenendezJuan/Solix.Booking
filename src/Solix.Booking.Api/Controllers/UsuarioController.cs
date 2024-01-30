using Microsoft.AspNetCore.Mvc;
using Solix.Booking.Application.Database.Usuario.Commands.CreateUser;
using Solix.Booking.Application.Database.Usuarios.Commands.ActualizarPassUsuario;
using Solix.Booking.Application.Database.Usuarios.Commands.ActualizarUsuario;
using Solix.Booking.Application.Database.Usuarios.Commands.CrearUsuario;
using Solix.Booking.Application.Database.Usuarios.Commands.EliminarUsuario;
using Solix.Booking.Application.Database.Usuarios.Queries.GetAllUser;
using Solix.Booking.Application.Database.Usuarios.Queries.GetUserById;
using Solix.Booking.Application.Database.Usuarios.Queries.GetUserByUsernameAndPassword;
using Solix.Booking.Application.Features;

namespace Solix.Booking.Api.Controllers
{
	[Route("api/v1/usuario")]
	[ApiController]
	public class UsuarioController : ControllerBase
	{
		[HttpPost("create")]
		public async Task<IActionResult> CrearUsuario([FromBody] CrearUsuarioDto crearUsuarioDto, [FromServices] ICrearUsuarioCommand crearUsuarioCommand)
		{

			var data = await crearUsuarioCommand.Ejecutar(crearUsuarioDto);

			return StatusCode(StatusCodes.Status201Created, ResponseApiService.Response(StatusCodes.Status201Created, data));
		}

		[HttpPut("update")]
		public async Task<IActionResult> ActualizarUsuario([FromBody] ActualizarUsuarioDto actualizarUsuarioDto, [FromServices] IActualizarUsuarioCommand actualizarUsuarioCommand)
		{
			var data = await actualizarUsuarioCommand.Ejecutar(actualizarUsuarioDto);
			return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data, "Se actualizo exitosamente"));
		}

		[HttpPut("update-password")]
		public async Task<IActionResult> ActualizarContraseña([FromBody] ActualizarContraseñaUsuarioDto actualizarContraseñaUsuarioDto, [FromServices] IActualizarContraseñaUsuarioCommand actualizarContraseñaUsuarioCommand)
		{
			var data = await actualizarContraseñaUsuarioCommand.Ejecutar(actualizarContraseñaUsuarioDto);
			return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data, "Se actualizo la password exitosamente"));
		}

		//Por parametro vamos a tener que recibir un Id de usuario para eliminarlo
		[HttpDelete("delete/{IdUsuario}")]
		//El id usuario lo agarra de lo que reciba por URL y entra al metodo
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
		//El fromBody solo se usa para los commands, para insertar data, en este caso al ser una query pasamos el Dto, pero dentro del metodo
		public async Task<IActionResult> ObtenerTodos([FromServices] IObtenerTodosLosUsuariosQuery obtenerTodosLosUsuarios)
		{
			//Dentro del metodo invoco el servicio y guardo el resultado en data
			var data = await obtenerTodosLosUsuarios.Ejecutar();
			if (data == null || data.Count == 0)
			{
				return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));
			}
			return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data, "Se han obtenido los usuarios"));
		}

		[HttpGet("get-by-id/{IdUsuario}")]
		//Los servicios son las INTERFACES
		public async Task<IActionResult> ObtenerUsuarioPorId(int IdUsuario, [FromServices] IObtenerUsuarioPorIdQuery obtenerUsuarioPorId)
		{
			if (IdUsuario == 0)
				return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest));

			var data = await obtenerUsuarioPorId.Ejecutar(IdUsuario);

			//Quizas el Id es valido pero no existe en la Db, tenemos que ver si no es null
			if (data == null)
				return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));

			return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data, $"Se ha obtenido el usuario con Id: {IdUsuario}"));
		}

		[HttpGet("get-by-username-pass/{nombreUsuario}/{password}")]
		public async Task<IActionResult> ObtenerPorNombreUsuarioyPass(string nombreUsuario, string password, [FromServices] IObtenerUsuarioPorNombreYContraseñaQuery porNombreYContraseñaQuery)
		{
			var data = await porNombreYContraseñaQuery.Ejecutar(nombreUsuario, password);

			if (data == null)
				return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound));

			return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data, "Se ha obtenido el usuario"));
		}
	}
}
