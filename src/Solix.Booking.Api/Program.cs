using Solix.Booking.Api;
using Solix.Booking.Application;
using Solix.Booking.Common;
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

//Para poder usar mis controladores
builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();
app.Run();