using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Solix.Booking.Application.Interfaces;

namespace Solix.Booking.Application.Database.Usuarios.Queries.GetAllUser
{
	public class ObtenerTodosLosUsuariosQuery : IObtenerTodosLosUsuariosQuery
	{
		private readonly IDatabaseService _databaseService;
		private readonly IMapper _mapper;

        public ObtenerTodosLosUsuariosQuery(IDatabaseService databaseService, IMapper mapper)
        {
            _databaseService = databaseService; 
            _mapper = mapper;
        }

        public async Task<List<ObtenerTodosLosUsuariosDto>> Ejecutar()
        {
            var ListEntity = await _databaseService.usuario.ToListAsync();
            //Convierto toda la lista de entidades de la DB, en el modelo que tengo
            return _mapper.Map<List<ObtenerTodosLosUsuariosDto>>(ListEntity);   
        }
    }
}
