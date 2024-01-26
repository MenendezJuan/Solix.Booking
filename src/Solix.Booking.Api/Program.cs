using Microsoft.EntityFrameworkCore;
using Solix.Booking.Application.Interfaces;
using Solix.Booking.Persistence.Extensions;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager Configuration = builder.Configuration;
IWebHostEnvironment environment = builder.Environment;

// Configuración de servicios
builder.Services.AddDbContextSqlServer(builder.Configuration);
builder.Services.AddServices();

var app = builder.Build();

app.MapPost("/createTest", async (IServiceProvider serviceProvider) =>
{
	// Resuelve el servicio en el ámbito del método
	using var scope = serviceProvider.CreateScope();
	var databaseService = scope.ServiceProvider.GetRequiredService<IDatabaseService>();

	var entidad = new Solix.Booking.Domain.Entities.Usuarios.Usuario
	{
		Nombre = "Juan",
		Apellido = "Menendez",
		NombreUsuario = "Juan123",
		Password = "CD#rDE"
	};

	await databaseService.usuario.AddAsync(entidad);
	await databaseService.SaveAsync();

	return "Create OK";
});

app.MapGet("/testGet", async (IDatabaseService _databaseService) =>
{
	// Obtener el IQueryable<Usuario>
	var usuariosQueryable = _databaseService.usuario.AsQueryable();

	// Realizar la operación ToListAsync
	var result = await usuariosQueryable.ToListAsync();

	// Retornar el resultado
	return result;
});
app.Run();