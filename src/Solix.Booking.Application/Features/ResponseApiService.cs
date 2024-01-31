using Solix.Booking.Domain.Models;

namespace Solix.Booking.Application.Features
{
	public static class ResponseApiService
	{
		//Al ser opcionales tanto data como message les pongo null
		public static BaseResponseModel Response(
			int statusCode, object Data = null, string message = null)
		{
			bool success = false;

			if (statusCode >= 200 && statusCode < 300)
			{
				//Significa que se completo exitosamente la peticion
				success = true;
			}

			var result = new BaseResponseModel()
			{
				StatusCode = statusCode,
				Success = success,
				data = Data,
				Message = message
			};
			return result;
		}
	}
}