﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using apivent.Infrastructure.Context;

namespace apivent.Migrations
{
    [DbContext(typeof(AppContexto))]
    [Migration("20200908044907_MigracionInicial")]
    partial class MigracionInicial
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
#pragma warning restore 612, 618
        }
    }
}
