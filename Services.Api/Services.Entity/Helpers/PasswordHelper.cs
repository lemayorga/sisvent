using Services.Entity.Security;

namespace Services.Entity.Helpers
{    public class PasswordHelper
    {
        public static Usuario EncodeNewPassword(Usuario usuario)
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