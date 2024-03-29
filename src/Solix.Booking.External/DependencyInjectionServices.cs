﻿using Microsoft.ApplicationInsights.AspNetCore.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Solix.Booking.Application.External.ApplicationInsights;
using Solix.Booking.Application.External.GetTokenJWT;
using Solix.Booking.Application.External.MailKitEmail;
using Solix.Booking.External.AddJWT;
using Solix.Booking.External.ApplicationInsights;
using Solix.Booking.External.EmailServices;
using System.Text;

namespace Solix.Booking.External
{
	public static class DependencyInjectionServices
	{
		public static IServiceCollection AddExternal(this IServiceCollection services,
			IConfiguration configuration)
		{
			services.AddSingleton<IGetTokenJWTService, GetTokenJWTService>();

			//Agrego el servicio y la configuracion
			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(option =>
			{
				option.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuer = true,
					ValidateAudience = true,
					ValidateLifetime = true,
					ValidateIssuerSigningKey = true,
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtConfig:SecretKey"])),
					ValidIssuer = configuration["JwtConfig:Issuer"],
					ValidAudience = configuration["JwtConfig:Audience"]
				};
			});



			services.AddApplicationInsightsTelemetry(new ApplicationInsightsServiceOptions
			{
				//Registramos el application insight
				ConnectionString = configuration["ApplicationInsights"]
			});


			services.AddSingleton<IInsertApplicationInsightsService, InsertApplicationInsightsService>();

			// Registro del servicio de envío de correo
			services.AddTransient<IEmailServices, SendEmailService>();

			return services;
		}


	}
}