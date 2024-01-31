using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Solix.Booking.Application.Interfaces;

namespace Solix.Booking.Application.Database.Usuarios.Queries.GetUserById
{
	public class ObtenerUsuarioPorIdQuery : IObtenerUsuarioPorIdQuery
	{
		private readonly IDatabaseService _databaseService;
		private readonly IMapper _mapper;

		public ObtenerUsuarioPorIdQuery(IDatabaseService databaseService, IMapper mapper)
		{
			_databaseService = databaseService;
			_mapper = mapper;
		}

		public async Task<ObtenerUsuarioPorIdDto> Ejecutar(int IdUsuario)
		{
			var entity = await _databaseService.usuario
				.FirstOrDefaultAsync(x => x.IdUsuario == IdUsuario);
			return _mapper.Map<ObtenerUsuarioPorIdDto>(entity);
		}
	}
}