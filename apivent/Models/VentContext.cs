using Microsoft.EntityFrameworkCore;

namespace apivent.Models
{
    public class VentContext : DbContext
    {
        public VentContext() : base() { }
        public VentContext(DbContextOptions options) : base(options) { }

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