using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace apivent.Migrations
{
    public partial class TablaUsuarios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    userId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    password = table.Column<string>(type: "varchar(800)", nullable: false),
                    passwordKey = table.Column<string>(type: "varchar(800)", nullable: false),
                    nombres = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    apellidos = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    correo = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false),
                    estado = table.Column<bool>(nullable: false, defaultValue: true),
                    fCreacion = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.userId);
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "userId", "apellidos", "correo", "nombres", "password", "passwordKey", "userName" },
                values: new object[] { 1, "administrador", "admin@admin.com", "administrador", "92-2C-B3-58-50-36-26-DF-9A-03-17-8C-C8-C3-A7-56", "K6Pb3CkUAm", "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
