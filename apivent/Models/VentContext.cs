using Microsoft.EntityFrameworkCore;

namespace apivent.Models
{
    public class VentContext : DbContext
    {
        public VentContext(DbContextOptions options) : base(options) { }

        public DbSet<Persona> Personas { get; set; }
    }
}