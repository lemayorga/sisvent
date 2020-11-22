
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using apivent.Application.DTOs.Security;
using apivent.Application.Interfaces.Securiry;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace apivent.Services
{
	public class SecurityTokenServices : ISecurityTokenService
	{
		
        /*** GENERAMOS EL TOKEN CON LA INFORMACIÓN DEL USUARIO ***/
        public string GenerarTokenJWT(IConfiguration configuration, UsuarioInfo usuarioInfo)
        {
            // Creacion del header
            var _symmetricSecurityKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(configuration["JWT:ClaveSecreta"])
            );
            var _signingCredentials = new SigningCredentials(
                    _symmetricSecurityKey, SecurityAlgorithms.HmacSha256
            );
            var _Header = new JwtHeader(_signingCredentials);

            // Creacion del claim
            var _Claims = new[] 
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.NameId, usuarioInfo.Id.ToString()),
                new Claim("nombre", usuarioInfo.Nombre),
                new Claim("apellidos", usuarioInfo.Apellidos),
                new Claim(JwtRegisteredClaimNames.Email, usuarioInfo.Email),
                new Claim(ClaimTypes.Role, usuarioInfo.Rol)
            };

            // Creacion del payload
            var _Payload = new JwtPayload
            (
                issuer: configuration["JWT:Issuer"],
                audience: configuration["JWT:Audience"],
                claims: _Claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddHours(24) // Exipra a la 24 horas.
            );

            // Creacion del token
            var _Token = new JwtSecurityToken( _Header,_Payload);

            return new JwtSecurityTokenHandler().WriteToken(_Token);
        } 
	}	
}

