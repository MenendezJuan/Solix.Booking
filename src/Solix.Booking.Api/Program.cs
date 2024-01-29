using Solix.Booking.Api;
using Solix.Booking.Application;
using Solix.Booking.Application.Database.Reservas.Commands.CrearReserva;
using Solix.Booking.Application.Database.Reservas.Queries.ObtenerReservasPorNroDocumento;
using Solix.Booking.Application.Database.Reservas.Queries.ObtenerTodasLasReservas;
using Solix.Booking.Common;
using Solix.Booking.Domain.Enums;
using Solix.Booking.External;
using Solix.Booking.Persistence;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager Configuration = builder.Configuration;
IWebHostEnvironment environment = builder.Environment;

//Agrego mi inyeccion de dependencias, apenas inicie la app
builder.Services
	.AddWebApi()
	.AddCommon()
	.AddApplication()
	.AddExternal(builder.Configuration)
	.AddPersistence(builder.Configuration);

var app = builder.Build();

app.MapPost("/testService", async (IObtenerReservasPorNroDocumentoQuery service) =>
{
	return await service.Ejecutar("12311");
});

app.Run();