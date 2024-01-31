namespace Solix.Booking.Domain.Models.EmailModel
{
	public class EmailDto
	{
		//Destino
		public string Para { get; set; } = String.Empty;
		//
		public string Asunto { get; set; } = String.Empty;
		//
		public string Contenido { get; set; } = String.Empty;
	}
}
