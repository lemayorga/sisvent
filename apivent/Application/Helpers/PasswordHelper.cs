using apivent.Application.DTOs.Security;
using apivent.Infrastructure.Models.Security;

namespace apivent.Application.Helpers
{
    public class PasswordHelper
    {
        public static Usuarios EncodeNewPassword(Usuarios usuario)
        {
           usuario.passwordKey = CryptString.GeneratePassword();
           string passwordEncode = CryptString.EncodePassword(usuario.password, usuario.passwordKey); 
           usuario.password = passwordEncode;
           return usuario;
        }

        public static string EncodePassword(string password, string passwordKey)
        {
            return CryptString.EncodePassword(password, passwordKey);  
        }
    }
}