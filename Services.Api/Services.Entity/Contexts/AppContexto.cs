using Microsoft.EntityFrameworkCore;
using Services.Entity.Common;
using Services.Entity.Security;
using Services.Entity.Seed;

namespace Services.Entity.Contexts
{
    public class AppContexto : DbContext
    {
        private readonly string _connectionString;
         public AppContexto(DbContextOptions<AppContexto> options): base(options) {}
        public AppContexto(string connectionString) : base(GetOptions(connectionString)) { _connectionString = connectionString; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
             SeedInitialize.Seed(modelBuilder);
        }
        private static DbContextOptions GetOptions(string connectionString) => SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
        
        public virtual DbSet<Persona> Personas { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        
    }
}