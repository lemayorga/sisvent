using Microsoft.EntityFrameworkCore;
using apivent.Infrastructure.Models;

namespace apivent.Infrastructure.Context
{
    public class AppContexto : DbContext
    {
        public AppContexto() : base() { }
        public AppContexto(DbContextOptions options) : base(options) { }        
        public virtual DbSet<Persona> Personas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Persona>(entidad =>
            {
                entidad.Property(propiedad => propiedad.nombres).HasColumnType("varchar(100)").IsRequired();
                entidad.Property(propiedad => propiedad.apellidos).HasColumnType("varchar(100)").IsRequired();
                entidad.Property(propiedad => propiedad.tipoPersona).HasColumnType("char(1)").IsRequired().HasDefaultValue("N");
            });
        }
    }
}