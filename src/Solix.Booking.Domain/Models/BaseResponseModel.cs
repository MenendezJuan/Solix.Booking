namespace Solix.Booking.Domain.Models
{
	public class BaseResponseModel
	{
		public int StatusCode { get; set; }
		public bool Success { get; set; }
		public string Message { get; set; }
		//Puede ser object, pero lo hacemos dynamic para poder setearle cualquier tipo de dato y accederlo sin necesidad de instanciarlo o inicializarlo
		public dynamic data { get; set; }
	}
}
