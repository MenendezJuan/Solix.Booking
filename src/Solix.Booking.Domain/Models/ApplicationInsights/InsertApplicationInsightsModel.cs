namespace Solix.Booking.Domain.Models.ApplicationInsights
{
	public class InsertApplicationInsightsModel
	{
		public InsertApplicationInsightsModel(string tipo, string contenido, string detalle)
		{
			//El Id de esta manera es autogenerado
			Id = Guid.NewGuid().ToString();
			Tipo = tipo;
			Contenido = contenido;
			Detalle = detalle;
		}

		public string Id { get; set; }
		public string Tipo { get; set; }
		public string Contenido { get; set; }
		public string Detalle { get; set; }
	}
}