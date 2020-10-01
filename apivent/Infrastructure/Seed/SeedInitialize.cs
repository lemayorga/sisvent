using Microsoft.EntityFrameworkCore;
using apivent.Infrastructure.Models;
using apivent.Infrastructure.Models.Security;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using apivent.Application.Helpers;

namespace apivent.Infrastructure.Seed
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

            modelBuilder.Entity<Usuarios>(entidad =>
            {
                entidad.HasKey(propiedad => propiedad.userId);
                entidad.Property(propiedad => propiedad.userId).UseIdentityColumn();
                entidad.Property(propiedad => propiedad.userName).HasColumnType("varchar(100)").IsRequired().HasMaxLength(100).IsUnicode();
                entidad.Property(propiedad => propiedad.password).HasColumnType("varchar(800)").IsRequired();
                entidad.Property(propiedad => propiedad.passwordKey).HasColumnType("varchar(800)").IsRequired();
                entidad.Property(propiedad => propiedad.nombres).HasColumnType("varchar(100)").IsRequired().HasMaxLength(100);
                entidad.Property(propiedad => propiedad.apellidos).HasColumnType("varchar(100)").IsRequired().HasMaxLength(100);
                entidad.Property(propiedad => propiedad.correo).HasColumnType("varchar(80)").IsRequired().HasMaxLength(80).IsUnicode();
                entidad.Property(propiedad => propiedad.fCreacion).HasColumnType("datetime").IsRequired().HasDefaultValueSql("getdate()");
                entidad.Property(propiedad => propiedad.estado).HasDefaultValue(true).IsRequired();
            }); 
                var usuario = new Usuarios
                {
                    userId = 1,
                    userName = "admin",
                    nombres = "administrador",
                    apellidos = "administrador",
                    correo = "admin@admin.com",
                    password = "admin@admin"
                };

                usuario = PasswordHelper.EncodeNewPassword(usuario);
                modelBuilder.Entity<Usuarios>().HasData(usuario);
        }
    }
}