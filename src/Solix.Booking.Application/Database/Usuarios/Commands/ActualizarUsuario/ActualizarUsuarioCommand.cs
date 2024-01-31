using AutoMapper;
using Solix.Booking.Application.Interfaces;

namespace Solix.Booking.Application.Database.Usuarios.Commands.ActualizarUsuario
{
	public class ActualizarUsuarioCommand : IActualizarUsuarioCommand
	{
		private readonly IDatabaseService _databaseService;
		private readonly IMapper _mapper;

		public ActualizarUsuarioCommand(IDatabaseService databaseService, IMapper mapper)
		{
			_databaseService = databaseService;
			_mapper = mapper;
		}

		public async Task<ActualizarUsuarioDto> Ejecutar(ActualizarUsuarioDto modelo)
		{
			var entity = _mapper.Map<Domain.Entities.Usuarios.Usuario>(modelo);
			//El update no es asincrono, por eso no usamos await.
			_databaseService.usuario.Update(entity);
			await _databaseService.SaveAsync();
			return modelo;
		}
	}
}