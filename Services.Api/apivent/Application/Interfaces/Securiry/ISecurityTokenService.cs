using apivent.Application.DTOs.Security;
using Microsoft.Extensions.Configuration;

namespace apivent.Application.Interfaces.Securiry
{
    public interface ISecurityTokenService
    {
        string GenerarTokenJWT(IConfiguration configuration, UsuarioInfo usuarioInfo);   
    }
}