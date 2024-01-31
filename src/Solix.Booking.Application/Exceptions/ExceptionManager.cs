using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Solix.Booking.Application.External.ApplicationInsights;
using Solix.Booking.Application.Features;
using Solix.Booking.Common.Constants;
using Solix.Booking.Domain.Models.ApplicationInsights;

namespace Solix.Booking.Application.Exceptions
{
	public class ExceptionManager : IExceptionFilter
	{
		private readonly IInsertApplicationInsightsService _insertApplicationInsightsService;
		public ExceptionManager(IInsertApplicationInsightsService insertApplicationInsightsService)
        {
            _insertApplicationInsightsService = insertApplicationInsightsService;	
        }
        public void OnException(ExceptionContext context)
		{
			context.Result = new ObjectResult(ResponseApiService.Response(StatusCodes.Status500InternalServerError,
				context.Exception.Message, null));

			var metric = new InsertApplicationInsightsModel(
				ApplicationInsightsConstants.METRIC_TYPE_ERROR,
				context.Exception.Message,
				//Paso todo el detalle de la excepcion a un string
				context.Exception.ToString()
				);

			_insertApplicationInsightsService.Ejecutar(metric);
		}
	}
}