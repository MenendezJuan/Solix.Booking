using AutoMapper;
using Solix.Booking.Application.Database.Usuario.Commands.CreateUser;
using Solix.Booking.Application.Interfaces;

namespace Solix.Booking.Application.Database.Usuarios.Commands.CreateUser
{
	internal class CrearUsuarioCommand
	{
		private readonly IDatabaseService _databaseService;
		private readonly IMapper _mapper;

		//Inyeccion de dependencias
		public CrearUsuarioCommand(IDatabaseService databaseService, IMapper mapper)
		{
			_databaseService = databaseService;
			_mapper = mapper;
		}

		public async Task<CrearUsuarioDto> Ejecutar(CrearUsuarioDto modelo)
		{
			var entity = _mapper.Map<Domain.Entities.Usuarios.Usuario>(modelo);
			await _databaseService.usuario.AddAsync(entity);
			await _databaseService.SaveAsync();
			return modelo;
		}
	}
}
