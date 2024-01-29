using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solix.Booking.Application.Database.Usuarios.Queries.GetUserById
{
	public interface IObtenerUsuarioPorIdQuery
	{
		Task<ObtenerUsuarioPorIdDto> Ejecutar(int IdUsuario);
	}
}
