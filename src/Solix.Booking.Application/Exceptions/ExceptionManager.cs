using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Solix.Booking.Application.Features;

namespace Solix.Booking.Application.Exceptions
{
	public class ExceptionManager : IExceptionFilter
	{
		public void OnException(ExceptionContext context)
		{
			context.Result = new ObjectResult(ResponseApiService.Response(StatusCodes.Status500InternalServerError,
				context.Exception.Message,null));
		}
	}
}
