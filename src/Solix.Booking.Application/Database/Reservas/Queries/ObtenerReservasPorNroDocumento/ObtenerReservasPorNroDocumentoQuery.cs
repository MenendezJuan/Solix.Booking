using Microsoft.EntityFrameworkCore;
using Solix.Booking.Application.Interfaces;

namespace Solix.Booking.Application.Database.Reservas.Queries.ObtenerReservasPorNroDocumento
{
	public class ObtenerReservasPorNroDocumentoQuery : IObtenerReservasPorNroDocumentoQuery
	{
		private readonly IDatabaseService _databaseService;

		public ObtenerReservasPorNroDocumentoQuery(IDatabaseService databaseService)
		{
			_databaseService = databaseService;
		}

		public async Task<List<ObtenerReservasPorNroDocumentoDto>> Ejecutar(string nroDocumento)
		{
			var result = await (from reservas in _databaseService.reserva
								join cliente in _databaseService.cliente
								on reservas.IdCliente equals cliente.IdCliente
								where cliente.Documento == nroDocumento
								select new ObtenerReservasPorNroDocumentoDto()
								{
									CodigoReserva = reservas.CodigoReserva,
									RegistrarFecha = reservas.RegistrarFecha,
									TipoReserva = reservas.TipoReserva
								}).ToListAsync();
			return result;
		}
	}
}