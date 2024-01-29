using AutoMapper;
using Solix.Booking.Application.Interfaces;
using Solix.Booking.Domain.Entities.Reservas;

namespace Solix.Booking.Application.Database.Reservas.Commands.CrearReserva
{
	public class CrearReservaCommand : ICrearReservaCommand
	{
		private readonly IDatabaseService _dataBaseService;
		private readonly IMapper _mapper;

        public CrearReservaCommand(IDatabaseService databaseService, IMapper mapper)
        {
            _dataBaseService = databaseService;
            _mapper = mapper;
        }

        public async Task<CrearReservaDto> Ejecutar(CrearReservaDto modelo)
        {
            var entity = _mapper.Map<Reserva>(modelo);
            await _dataBaseService.reserva.AddAsync(entity);
            await _dataBaseService.SaveAsync();
            return modelo;
        }
    }
}
