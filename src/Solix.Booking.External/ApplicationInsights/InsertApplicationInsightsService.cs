using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.Extensions.Configuration;
using Solix.Booking.Application.External.ApplicationInsights;
using Solix.Booking.Domain.Models.ApplicationInsights;

namespace Solix.Booking.External.ApplicationInsights
{
	public class InsertApplicationInsightsService : IInsertApplicationInsightsService
	{
		private readonly IConfiguration _configuration;

		public InsertApplicationInsightsService(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		//Retorno T o F, si se ejecuto correctamente o no
		public bool Ejecutar(InsertApplicationInsightsModel metric)
		{
			if (metric == null)
				throw new ArgumentNullException(nameof(metric));

			TelemetryConfiguration config = new TelemetryConfiguration();
			config.ConnectionString = _configuration["ApplicationInsights"];
			var _telemetryCliente = new TelemetryClient(config);

			//Creo el diccionario para pasar en el parametro
			var properties = new Dictionary<string, string>
			{
				//Creo los objetos
				{ "Id", metric.Id },
				{"Content", metric.Contenido },
				{"Detail", metric.Detalle }
			};

			_telemetryCliente.TrackTrace(metric.Tipo, SeverityLevel.Information, properties);
			return true;
		}
	}
}