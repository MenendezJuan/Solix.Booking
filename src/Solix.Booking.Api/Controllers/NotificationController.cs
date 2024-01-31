using Microsoft.AspNetCore.Mvc;
using Solix.Booking.Application.Exceptions;
using Solix.Booking.Application.External.MailKitEmail;
using Solix.Booking.Domain.Models.EmailModel;

namespace Solix.Booking.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[TypeFilter(typeof(ExceptionManager))]
	public class NotificationController : ControllerBase
	{
		private readonly IEmailServices _emailServices;
        public NotificationController(IEmailServices emailServices)
        {
            _emailServices = emailServices;	
        }

		[HttpPost]
		public IActionResult SendEmail(EmailDto request)
		{
			_emailServices.SendEmail(request);
			return Ok();
		}
    }
}
