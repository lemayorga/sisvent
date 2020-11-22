// using System.Linq;
// using apivent.Application.Interfaces.Securiry;
// using apivent.Application.Repositories;
// using apivent.Infrastructure.Context;
// using apivent.Infrastructure.Models.Security;
// using apivent.Application.Helpers;
// using apivent.Application.DTOs.Security;

// namespace apivent.Services.Security
// {
//     public class SecurityServices :  GenericBaseRepository<Usuario>, ISecurityService
//     {
//         public SecurityServices(AppContexto context) : base(context) { }
//         public void Registration(Usuario newUsuario)  
//         {  
//             newUsuario = PasswordHelper.EncodeNewPassword(newUsuario); 
//         }

//         public UsuarioInfo Autentication(string usuario, string contrasena)  
//         {  
//             usuario = usuario.Trim(); contrasena = contrasena.Trim();
//             var user =  context.Usuarios.FirstOrDefault(data => data.userName == usuario);
//             if (user != null)  
//             {  
//                 var encodingPasswordString = PasswordHelper.EncodePassword(contrasena, user.passwordKey);
//                 var resultado = context.Usuarios.FirstOrDefault(data => data.userName == usuario && data.password == encodingPasswordString);               
//                 if(resultado != null){
//                     return new UsuarioInfo()
//                     {
//                         Id = new System.Guid("B5D233F0-6EC2-4950-8CD7-F44D16EC878F"),
//                         Nombre = resultado.nombres,
//                         Apellidos = resultado.apellidos,
//                         Email = resultado.correo,
//                         Rol = "Administrador"
//                     };
//                 }
//                 return null;
//             }
//             return null;
//         }
//     }
// }

// // https://www.c-sharpcorner.com/UploadFile/145c93/save-password-using-salted-hashing/

