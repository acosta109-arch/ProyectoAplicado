using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoAplicado.Migrations
{
    /// <inheritdoc />
    public partial class AddNewTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bebidas",
                columns: table => new
                {
                    BebidaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: false),
                    Tipo = table.Column<string>(type: "TEXT", nullable: false),
                    Precio = table.Column<decimal>(type: "TEXT", nullable: false),
                    Disponibilidad = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bebidas", x => x.BebidaId);
                });

            migrationBuilder.CreateTable(
                name: "Cocineros",
                columns: table => new
                {
                    CocineroId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NombreCompleto = table.Column<string>(type: "TEXT", nullable: false),
                    Especialidad = table.Column<string>(type: "TEXT", nullable: false),
                    Telefono = table.Column<string>(type: "TEXT", nullable: false),
                    Estado = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cocineros", x => x.CocineroId);
                });

            migrationBuilder.CreateTable(
                name: "meseras",
                columns: table => new
                {
                    MeseraId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    Apellido = table.Column<string>(type: "TEXT", nullable: false),
                    Telefono = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_meseras", x => x.MeseraId);
                });

            migrationBuilder.CreateTable(
                name: "Mesas",
                columns: table => new
                {
                    MesaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Numero = table.Column<int>(type: "INTEGER", nullable: false),
                    Capacidad = table.Column<int>(type: "INTEGER", nullable: false),
                    Estado = table.Column<string>(type: "TEXT", nullable: false),
                    MeseraId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mesas", x => x.MesaId);
                    table.ForeignKey(
                        name: "FK_Mesas_meseras_MeseraId",
                        column: x => x.MeseraId,
                        principalTable: "meseras",
                        principalColumn: "MeseraId");
                });

            migrationBuilder.CreateTable(
                name: "Comandas",
                columns: table => new
                {
                    ComandaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MesaId = table.Column<int>(type: "INTEGER", nullable: false),
                    MeseraId = table.Column<int>(type: "INTEGER", nullable: true),
                    CocineroId = table.Column<int>(type: "INTEGER", nullable: true),
                    Estado = table.Column<string>(type: "TEXT", nullable: false),
                    FechaHora = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comandas", x => x.ComandaId);
                    table.ForeignKey(
                        name: "FK_Comandas_Cocineros_CocineroId",
                        column: x => x.CocineroId,
                        principalTable: "Cocineros",
                        principalColumn: "CocineroId");
                    table.ForeignKey(
                        name: "FK_Comandas_Mesas_MesaId",
                        column: x => x.MesaId,
                        principalTable: "Mesas",
                        principalColumn: "MesaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comandas_meseras_MeseraId",
                        column: x => x.MeseraId,
                        principalTable: "meseras",
                        principalColumn: "MeseraId");
                });

            migrationBuilder.CreateTable(
                name: "Comidas",
                columns: table => new
                {
                    ComidaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: false),
                    Categoria = table.Column<string>(type: "TEXT", nullable: false),
                    Precio = table.Column<decimal>(type: "TEXT", nullable: false),
                    Disponibilidad = table.Column<string>(type: "TEXT", nullable: false),
                    ComandaId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comidas", x => x.ComidaId);
                    table.ForeignKey(
                        name: "FK_Comidas_Comandas_ComandaId",
                        column: x => x.ComandaId,
                        principalTable: "Comandas",
                        principalColumn: "ComandaId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comandas_CocineroId",
                table: "Comandas",
                column: "CocineroId");

            migrationBuilder.CreateIndex(
                name: "IX_Comandas_MesaId",
                table: "Comandas",
                column: "MesaId");

            migrationBuilder.CreateIndex(
                name: "IX_Comandas_MeseraId",
                table: "Comandas",
                column: "MeseraId");

            migrationBuilder.CreateIndex(
                name: "IX_Comidas_ComandaId",
                table: "Comidas",
                column: "ComandaId");

            migrationBuilder.CreateIndex(
                name: "IX_Mesas_MeseraId",
                table: "Mesas",
                column: "MeseraId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bebidas");

            migrationBuilder.DropTable(
                name: "Comidas");

            migrationBuilder.DropTable(
                name: "Comandas");

            migrationBuilder.DropTable(
                name: "Cocineros");

            migrationBuilder.DropTable(
                name: "Mesas");

            migrationBuilder.DropTable(
                name: "meseras");
        }
    }
}
