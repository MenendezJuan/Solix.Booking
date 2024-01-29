using Microsoft.EntityFrameworkCore;
using Solix.Booking.Application.Interfaces;

namespace Solix.Booking.Application.Database.Usuarios.Commands.ActualizarPassUsuario
{
	public class ActualizarContraseñaUsuarioCommand : IActualizarContraseñaUsuarioCommand
	{
		private readonly IDatabaseService _databaseService;

		public ActualizarContraseñaUsuarioCommand(IDatabaseService databaseService)
		{
			_databaseService = databaseService; 
		}

		public async Task<bool> Ejecutar(ActualizarContraseñaUsuarioDto modelo)
		{
			var entity = await _databaseService.usuario
				.FirstOrDefaultAsync(x => x.IdUsuario == modelo.IdUsuario);

			if(entity == null)
			{
				return false;   
			}

			entity.Password = modelo.Password;

			return await _databaseService.SaveAsync();

		}
	}
}
