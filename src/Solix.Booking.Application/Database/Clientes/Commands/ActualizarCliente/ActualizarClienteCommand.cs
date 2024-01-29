using AutoMapper;
using Solix.Booking.Application.Database.Usuarios.Commands.ActualizarUsuario;
using Solix.Booking.Application.Interfaces;

namespace Solix.Booking.Application.Database.Clientes.Commands.ActualizarCliente
{
	public class ActualizarClienteCommand : IActualizarClienteCommand
	{
		private readonly IDatabaseService _databaseService;
		private readonly IMapper _mapper;

		public ActualizarClienteCommand(IDatabaseService databaseService, IMapper mapper)
		{
			_databaseService = databaseService;
			_mapper = mapper;
		}

		public async Task<ActualizarClienteDto> Ejecutar(ActualizarClienteDto modelo)
		{
			var entity = _mapper.Map<Domain.Entities.Clientes.Cliente>(modelo);
			//El update no es asincrono, por eso no usamos await.
			_databaseService.cliente.Update(entity);
			await _databaseService.SaveAsync();
			return modelo;
		}
	}
}
