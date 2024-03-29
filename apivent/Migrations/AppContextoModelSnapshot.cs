﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using apivent.Infrastructure.Context;

namespace apivent.Migrations
{
    [DbContext(typeof(AppContexto))]
    partial class AppContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("apivent.Infrastructure.Models.Persona", b =>
                {
                    b.Property<int>("personaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("apellidos")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("nombres")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("tipoPersona")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(1)")
                        .HasDefaultValue("N");

                    b.HasKey("personaId");

                    b.ToTable("Personas");
                });

            modelBuilder.Entity("apivent.Infrastructure.Models.Security.Usuario", b =>
                {
                    b.Property<int>("usuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("apellidos")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("correo")
                        .IsRequired()
                        .HasColumnType("varchar(80)")
                        .HasMaxLength(80)
                        .IsUnicode(true);

                    b.Property<bool>("estado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<DateTime>("fCreacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("nombres")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("varchar(800)");

                    b.Property<string>("passwordKey")
                        .IsRequired()
                        .HasColumnType("varchar(800)");

                    b.Property<string>("userName")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(true);

                    b.HasKey("usuarioId");

                    b.ToTable("Usuarios");

                    b.HasData(
                        new
                        {
                            usuarioId = 1,
                            apellidos = "administrador",
                            correo = "admin@admin.com",
                            estado = false,
                            fCreacion = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            nombres = "administrador",
                            password = "C3-84-CB-DA-11-5B-68-D0-F5-67-51-73-EE-13-C6-3D",
                            passwordKey = "EQ987C6cKn",
                            userName = "admin"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
