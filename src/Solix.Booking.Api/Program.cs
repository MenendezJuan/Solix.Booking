using Microsoft.EntityFrameworkCore;
using Solix.Booking.Persistence.Database;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DatabaseService>(options=>
options.UseSqlServer(builder.Configuration["SqlConnectionString"]));

var app = builder.Build();


app.Run();

