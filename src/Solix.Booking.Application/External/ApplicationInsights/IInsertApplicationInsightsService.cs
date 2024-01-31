using Solix.Booking.Domain.Models.ApplicationInsights;

namespace Solix.Booking.Application.External.ApplicationInsights
{
	public interface IInsertApplicationInsightsService
	{
		bool Ejecutar(InsertApplicationInsightsModel metric);
	}
}