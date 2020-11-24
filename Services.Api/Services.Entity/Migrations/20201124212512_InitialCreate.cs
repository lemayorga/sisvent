using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Services.Entity.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    personaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombres = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    apellidos = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    tipoPersona = table.Column<string>(type: "char(1)", nullable: false, defaultValue: "N")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.personaId);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    usuarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    password = table.Column<string>(type: "varchar(800)", nullable: false),
                    passwordKey = table.Column<string>(type: "varchar(800)", nullable: false),
                    nombres = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    apellidos = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    correo = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false),
                    estado = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    fCreacion = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.usuarioId);
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "usuarioId", "apellidos", "correo", "nombres", "password", "passwordKey", "userName" },
                values: new object[] { 1, "administrador", "admin@admin.com", "administrador", "35-30-7D-47-39-42-26-3F-C5-AA-31-60-61-60-BF-32", "VD9SNPT8Kv", "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Personas");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
