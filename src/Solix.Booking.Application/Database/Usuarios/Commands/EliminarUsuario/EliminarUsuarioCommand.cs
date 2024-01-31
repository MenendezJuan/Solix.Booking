using Microsoft.EntityFrameworkCore;
using Solix.Booking.Application.Interfaces;

namespace Solix.Booking.Application.Database.Usuarios.Commands.EliminarUsuario
{
	public class EliminarUsuarioCommand : IEliminarUsuarioCommand
	{
		private readonly IDatabaseService _databaseService;

		public EliminarUsuarioCommand(IDatabaseService databaseService)
		{
			_databaseService = databaseService;
		}

		public async Task<bool> Ejecutar(int IdUsuario)
		{
			var entity = await _databaseService.usuario
				.FirstOrDefaultAsync(x => x.IdUsuario == IdUsuario);
			if (entity == null)
			{
				return false;
			}

			_databaseService.usuario.Remove(entity);
			return await _databaseService.SaveAsync();
		}
	}
}