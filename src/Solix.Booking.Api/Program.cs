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

app.Run();