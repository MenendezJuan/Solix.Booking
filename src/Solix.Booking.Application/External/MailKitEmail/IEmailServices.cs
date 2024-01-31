using Solix.Booking.Domain.Models.EmailModel;

namespace Solix.Booking.Application.External.MailKitEmail
{
	public interface IEmailServices
	{
		void SendEmail(EmailDto request);
	}
}
