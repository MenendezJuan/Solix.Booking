using Microsoft.EntityFrameworkCore;
using Solix.Booking.Application.Interfaces;

namespace Solix.Booking.Application.Database.Clientes.Commands.EliminarCliente
{
	public class EliminarClienteCommand : IEliminarClienteCommand
	{
		private readonly IDatabaseService _databaseService;

		public EliminarClienteCommand(IDatabaseService databaseService)
		{
			_databaseService = databaseService;
		}

		public async Task<bool> Ejecutar(int IdCliente)
		{
			var entity = await _databaseService.cliente
				.FirstOrDefaultAsync(x => x.IdCliente == IdCliente);
			if (entity == null)
			{
				return false;
			}

			_databaseService.cliente.Remove(entity);
			return await _databaseService.SaveAsync();
		}
	}
}