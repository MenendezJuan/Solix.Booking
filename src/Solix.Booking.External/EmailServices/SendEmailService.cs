using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit.Text;
using Solix.Booking.Application.External.MailKitEmail;
using Solix.Booking.Domain.Models.EmailModel;
using MailKit.Net.Smtp;

namespace Solix.Booking.External.EmailServices
{
	public class SendEmailService : IEmailServices
	{
		private readonly IConfiguration _configuration;
		public SendEmailService(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		// Configuramos el correo
		public void SendEmail(EmailDto request)
		{
			var email = new MimeMessage();
			// Desde donde enviamos nuestro mail, accede al appsettings
			email.From.Add(MailboxAddress.Parse(_configuration.GetSection("Email:Username").Value));
			// A quien le enviamos el correo, el request es lo que recibimos por parámetros
			email.To.Add(MailboxAddress.Parse(request.Para));
			// Establezco el asunto del correo
			email.Subject = request.Asunto;
			email.Body = new TextPart(TextFormat.Html)
			{
				Text = request.Contenido
			};

			using var smtp = new SmtpClient();

			smtp.Connect(
				_configuration.GetSection("Email:Host").Value,
				Convert.ToInt32(_configuration.GetSection("Email:Port").Value),
				SecureSocketOptions.StartTls
			);

			smtp.Authenticate(
				_configuration.GetSection("Email:Username").Value,
				_configuration.GetSection("Email:Password").Value
			);

			// Enviamos el correo
			smtp.Send(email);

			// Desconectamos el cliente después de enviar el correo
			smtp.Disconnect(true);

		}
	}
}
