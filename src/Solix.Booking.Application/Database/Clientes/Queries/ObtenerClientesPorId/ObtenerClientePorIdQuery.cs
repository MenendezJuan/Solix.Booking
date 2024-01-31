using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Solix.Booking.Application.Interfaces;

namespace Solix.Booking.Application.Database.Clientes.Queries.ObtenerClientesPorId
{
	public class ObtenerClientePorIdQuery : IObtenerClientePorIdQuery
	{
		private readonly IDatabaseService _databaseService;
		private readonly IMapper _mapper;

		public ObtenerClientePorIdQuery(IDatabaseService databaseService, IMapper mapper)
		{
			_databaseService = databaseService;
			_mapper = mapper;
		}

		public async Task<ObtenerClientePorIdDto> Ejecutar(int IdCliente)
		{
			var entity = await _databaseService.cliente
				.FirstOrDefaultAsync(x => x.IdCliente == IdCliente);
			return _mapper.Map<ObtenerClientePorIdDto>(entity);
		}
	}
}