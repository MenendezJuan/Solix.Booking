using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Solix.Booking.Application.Interfaces;

namespace Solix.Booking.Application.Database.Clientes.Queries.ObtenerClientesPorDocumento
{
	public class ObtenerClientePorDocumentoQuery : IObtenerClientePorDocumentoQuery
	{
		private readonly IDatabaseService _databaseService;
		private readonly IMapper _mapper;

		public ObtenerClientePorDocumentoQuery(IDatabaseService databaseService, IMapper mapper)
		{
			_databaseService = databaseService;
			_mapper = mapper;
		}

		public async Task<ObtenerClientePorDocumentoDto> Ejecutar(string documento)
		{
			var entity = await _databaseService.cliente
				.FirstOrDefaultAsync(x => x.Documento == documento);
			return _mapper.Map<ObtenerClientePorDocumentoDto>(entity);
		}
	}
}
