using Solix.Booking.Application.Database.Usuario.Commands.CreateUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solix.Booking.Application.Database.Usuarios.Commands.CrearUsuario
{
	public interface ICrearUsuarioCommand
	{
		Task<CrearUsuarioDto> Ejecutar(CrearUsuarioDto modelo);
	}
}
