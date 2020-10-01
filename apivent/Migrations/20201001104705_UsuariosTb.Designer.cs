﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using apivent.Infrastructure.Context;

namespace apivent.Migrations
{
    [DbContext(typeof(AppContexto))]
    [Migration("20201001104705_UsuariosTb")]
    partial class UsuariosTb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                        .HasColumnType("varchar(100)");

                    b.Property<string>("nombres")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

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
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("correo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("estado")
                        .HasColumnType("bit");

                    b.Property<DateTime>("fCreacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("nombres")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("passwordKey")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("usuarioId");

                    b.ToTable("Usuarios");
                });
#pragma warning restore 612, 618
        }
    }
}
