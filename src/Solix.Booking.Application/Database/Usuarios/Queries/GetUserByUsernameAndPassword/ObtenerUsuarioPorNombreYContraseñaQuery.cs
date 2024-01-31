using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Solix.Booking.Application.Interfaces;

namespace Solix.Booking.Application.Database.Usuarios.Queries.GetUserByUsernameAndPassword
{
	public class ObtenerUsuarioPorNombreYContraseñaQuery : IObtenerUsuarioPorNombreYContraseñaQuery
	{
		private readonly IDatabaseService _databaseService;
		private readonly IMapper _mapper;

		public ObtenerUsuarioPorNombreYContraseñaQuery(IDatabaseService databaseService, IMapper mapper)
		{
			_databaseService = databaseService;
			_mapper = mapper;
		}

		public async Task<ObtenerUsuarioPorNombreYContraseñaDto> Ejecutar(string nombreUsuario, string password)
		{
			var entity = await _databaseService.usuario
				.FirstOrDefaultAsync(x => x.NombreUsuario == nombreUsuario && x.Password == password);
			return _mapper.Map<ObtenerUsuarioPorNombreYContraseñaDto>(entity);
		}
	}
}