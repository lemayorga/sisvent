using System;

namespace Services.Logic.DTOs.Security
{
    public class UsuarioInfo
    {
        public Guid Id { get; set; }
        public string userName { get; set; } 
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }
        public string Rol { get; set; }
    }
}