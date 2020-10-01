using apivent.Application.DTOs.Security;
using apivent.Infrastructure.Models.Security;

namespace apivent.Application.Interfaces.Securiry
{
    public interface ISecurityService
    {
        void Registration(Usuario newUsuario);
        UsuarioInfo Autentication(string usuario, string contrasena);
    }
}