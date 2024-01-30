using Microsoft.EntityFrameworkCore;
using Solix.Booking.Application.Interfaces;

namespace Solix.Booking.Application.Database.Reservas.Queries.ObtenerTodasLasReservas
{
	public class ObtenerTodasLasReservasQuery : IObtenerTodasLasReservasQuery 
	{
		private readonly IDatabaseService _databaseService;

		public ObtenerTodasLasReservasQuery(IDatabaseService databaseService)
		{
			_databaseService = databaseService;
		}

		//No es necesario mapear siempre
		public async Task<List<ObtenerTodasLasReservasDto>> Ejecutar()
		{
			//Voy a realizar consultas con LINQ
			var result = await (from reserva in _databaseService.reserva
								join cliente in _databaseService.cliente
								on reserva.IdCliente equals cliente.IdCliente
								select new ObtenerTodasLasReservasDto
								{
									IdReserva = reserva.IdReserva,
									CodigoReserva = reserva.CodigoReserva,
									RegistrarFecha = reserva.RegistrarFecha,
									TipoReserva = reserva.TipoReserva,
									ClienteNombre = cliente.NombreCompleto,
									DocumentoCliente = cliente.Documento
								}).ToListAsync();
			return result;
		}
	}
}
