using Microsoft.EntityFrameworkCore;
using apivent.Infrastructure.Models;
using apivent.Infrastructure.Models.Security;
using apivent.Infrastructure.Seed;

namespace apivent.Infrastructure.Context
{
    public class AppContexto : DbContext
    {
        public AppContexto() : base() { }
        public AppContexto(DbContextOptions options) : base(options) { }        
        public virtual DbSet<Persona> Personas { get; set; }
       public virtual DbSet<Usuario> Usuarios { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
             SeedInitialize.Seed(modelBuilder);
        }
    }
}