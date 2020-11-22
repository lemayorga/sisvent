using Microsoft.EntityFrameworkCore;
using Services.Entity.Common;
using Services.Entity.Helpers;
using Services.Entity.Security;

namespace Services.Entity.Seed
{
    public static class SeedInitialize
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Persona>(entidad =>
            {
                entidad.Property(propiedad => propiedad.nombres).HasColumnType("varchar(100)").IsRequired().HasMaxLength(100);
                entidad.Property(propiedad => propiedad.apellidos).HasColumnType("varchar(100)").IsRequired().HasMaxLength(100);
                entidad.Property(propiedad => propiedad.tipoPersona).HasColumnType("char(1)").IsRequired().HasDefaultValue("N");
            });

            modelBuilder.Entity<Usuario>(entidad =>
            {
                // entidad.HasKey(propiedad => propiedad.usuarioId);
                // entidad.Property(propiedad => propiedad.usuarioId).UseIdentityColumn();
                entidad.Property(propiedad => propiedad.userName).HasColumnType("varchar(100)").IsRequired().HasMaxLength(100).IsUnicode();
                entidad.Property(propiedad => propiedad.password).HasColumnType("varchar(800)").IsRequired();
                entidad.Property(propiedad => propiedad.passwordKey).HasColumnType("varchar(800)").IsRequired();
                entidad.Property(propiedad => propiedad.nombres).HasColumnType("varchar(100)").IsRequired().HasMaxLength(100);
                entidad.Property(propiedad => propiedad.apellidos).HasColumnType("varchar(100)").IsRequired().HasMaxLength(100);
                entidad.Property(propiedad => propiedad.correo).HasColumnType("varchar(80)").IsRequired().HasMaxLength(80).IsUnicode();
                entidad.Property(propiedad => propiedad.fCreacion).HasColumnType("datetime").IsRequired().HasDefaultValueSql("getdate()");
                entidad.Property(propiedad => propiedad.estado).HasDefaultValue(true).IsRequired();
            }); 
                var usuario = new Usuario
                {
                    usuarioId = 1,
                    userName = "admin",
                    nombres = "administrador",
                    apellidos = "administrador",
                    correo = "admin@admin.com",
                    password = "admin@admin"
                };

                usuario = PasswordHelper.EncodeNewPassword(usuario);
                modelBuilder.Entity<Usuario>().HasData(usuario);
        }
    }
}