using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solix.Booking.Application.Database.Usuarios.Queries.GetUserById
{
	public class ObtenerUsuarioPorIdDto
	{
		public string Nombre { get; set; }
		public string Apellido { get; set; }
		public string NombreUsuario { get; set; }
		public string Password { get; set; }
	}
}
