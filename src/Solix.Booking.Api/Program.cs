using Solix.Booking.Application.Interfaces;
using Solix.Booking.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Configuraci�n de servicios
builder.Services.AddDbContextSqlServer(builder.Configuration);
builder.Services.AddServices(); // Llamando al m�todo de extensi�n AddServices

var app = builder.Build();

app.MapPost("/createTest", async (IServiceProvider serviceProvider) =>
{
	// Resuelve el servicio en el �mbito del m�todo
	using var scope = serviceProvider.CreateScope();
	var databaseService = scope.ServiceProvider.GetRequiredService<IDatabaseService>();

	var entidad = new Solix.Booking.Domain.Entities.Usuarios.Usuario
	{
		Nombre = "Juan",
		Apellido = "Menendez",
		NombreUsuario = "Juan123",
		Password = "CD#rDE"
	};

	await databaseService.usuarios.AddAsync(entidad);
	await databaseService.SaveAsync();

	return "Create OK";
});

app.Run();