using AutoMapper;
using Solix.Booking.Application.Interfaces;

namespace Solix.Booking.Application.Database.Clientes.Commands.CrearCliente
{
	public class CrearClienteCommand : ICrearClienteCommand
	{
		private readonly IDatabaseService _databaseService;
		private readonly IMapper _mapper;

		//Inyeccion de dependencias
		public CrearClienteCommand(IDatabaseService databaseService, IMapper mapper)
		{
			_databaseService = databaseService;
			_mapper = mapper;
		}

		public async Task<CrearClienteDto> Ejecutar(CrearClienteDto modelo)
		{
			var entity = _mapper.Map<Domain.Entities.Clientes.Cliente>(modelo);
			await _databaseService.cliente.AddAsync(entity);
			await _databaseService.SaveAsync();
			return modelo;
		}
	}
}
