using System;

namespace Services.Entity.Security
{
    public class Usuario
    {
        public int usuarioId { get; set; }
        public string userName { get; set; }   
        public string password { get ; set ; }
        public string passwordKey { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string correo { get; set; }
        public bool estado { get; set; }
        public DateTime fCreacion { get; set; }
    }
}