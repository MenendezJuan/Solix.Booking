using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Solix.Booking.Application.Interfaces;

namespace Solix.Booking.Application.Database.Clientes.Queries.ObtenerTodosLosClientes
{
	public class ObtenerTodosLosClientesQuery : IObtenerTodosLosClientesQuery
	{
		private readonly IDatabaseService _databaseService;
		private readonly IMapper _mapper;

        public ObtenerTodosLosClientesQuery(IDatabaseService databaseService, IMapper mapper)
        {
            _databaseService = databaseService;
            _mapper = mapper;
        }

        public async Task<List<ObtenerTodosLosClientesDto>> Ejecutar()
        {
            var listEntity = await _databaseService.cliente.ToListAsync();
            return _mapper.Map<List<ObtenerTodosLosClientesDto>>(listEntity);
        }
    }
}
