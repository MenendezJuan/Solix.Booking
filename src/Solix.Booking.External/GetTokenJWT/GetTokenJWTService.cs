using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Solix.Booking.Application.External.GetTokenJWT;

namespace Solix.Booking.External.AddJWT
{
	public class GetTokenJWTService : IGetTokenJWTService
    {
        private readonly IConfiguration _configuration;
        public GetTokenJWTService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //Creo un metodo que devuelve string, dado que el token es un string
        
        public string Ejecutar(string id)
        {
			var tokenHandler = new JwtSecurityTokenHandler();
			string key = _configuration["JwtConfig:SecretKey"] ?? string.Empty;

			var signinKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(
					new Claim[]
					{
			new Claim(ClaimTypes.NameIdentifier, id)
					}),
				Expires = DateTime.UtcNow.AddMinutes(1),
				SigningCredentials = new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256Signature),
				Issuer = _configuration["JwtConfig:Issuer"],
				Audience = _configuration["JwtConfig:Audience"]
			};

			var token = tokenHandler.CreateToken(tokenDescriptor);
			var tokenString = tokenHandler.WriteToken(token);
			return tokenString;

		}


    }
}
