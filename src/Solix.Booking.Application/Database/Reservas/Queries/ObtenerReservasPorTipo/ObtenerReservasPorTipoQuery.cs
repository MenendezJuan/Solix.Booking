using Microsoft.EntityFrameworkCore;
using Solix.Booking.Application.Interfaces;

namespace Solix.Booking.Application.Database.Reservas.Queries.ObtenerReservasPorTipo
{
	public class ObtenerReservasPorTipoQuery : IObtenerReservasPorTipoQuery
	{
		private readonly IDatabaseService _databaseService;

		public ObtenerReservasPorTipoQuery(IDatabaseService databaseService)
		{
			_databaseService = databaseService;
		}

		public async Task<List<ObtenerReservasPorTipoDto>> Ejecutar(string tipo)
		{
			var result = await (from reservas in _databaseService.reserva
								join cliente in _databaseService.cliente
								on reservas.IdCliente equals cliente.IdCliente
								where reservas.TipoReserva == tipo

								select new ObtenerReservasPorTipoDto
								{
									CodigoReserva = reservas.CodigoReserva,
									RegistrarFecha = reservas.RegistrarFecha,
									TipoReserva = reservas.TipoReserva,
									NombreCompletoCliente = cliente.NombreCompleto,
									DocumentoCliente = cliente.Documento
								}).ToListAsync();
			return result;
		}
	}
}