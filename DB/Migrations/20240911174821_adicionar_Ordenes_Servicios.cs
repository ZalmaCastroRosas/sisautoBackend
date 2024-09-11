using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DB.Migrations
{
    /// <inheritdoc />
    public partial class adicionar_Ordenes_Servicios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ordenes",
                columns: table => new
                {
                    OrdenID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClienteID = table.Column<int>(type: "integer", nullable: false),
                    Fecha = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Total = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordenes", x => x.OrdenID);
                    table.ForeignKey(
                        name: "FK_Ordenes_Clientes_ClienteID",
                        column: x => x.ClienteID,
                        principalTable: "Clientes",
                        principalColumn: "ClienteID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Servicios",
                columns: table => new
                {
                    ServicioID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NombreServicio = table.Column<string>(type: "text", nullable: false),
                    DescripcionServicio = table.Column<string>(type: "text", nullable: false),
                    Costo = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicios", x => x.ServicioID);
                });

            migrationBuilder.CreateTable(
                name: "DetalleOrdenes",
                columns: table => new
                {
                    DetalleOrdenID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrdenID = table.Column<int>(type: "integer", nullable: false),
                    ServicioID = table.Column<int>(type: "integer", nullable: false),
                    Cantidad = table.Column<int>(type: "integer", nullable: false),
                    Subtotal = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleOrdenes", x => x.DetalleOrdenID);
                    table.ForeignKey(
                        name: "FK_DetalleOrdenes_Ordenes_OrdenID",
                        column: x => x.OrdenID,
                        principalTable: "Ordenes",
                        principalColumn: "OrdenID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetalleOrdenes_Servicios_ServicioID",
                        column: x => x.ServicioID,
                        principalTable: "Servicios",
                        principalColumn: "ServicioID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetalleOrdenes_OrdenID",
                table: "DetalleOrdenes",
                column: "OrdenID");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleOrdenes_ServicioID",
                table: "DetalleOrdenes",
                column: "ServicioID");

            migrationBuilder.CreateIndex(
                name: "IX_Ordenes_ClienteID",
                table: "Ordenes",
                column: "ClienteID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetalleOrdenes");

            migrationBuilder.DropTable(
                name: "Ordenes");

            migrationBuilder.DropTable(
                name: "Servicios");
        }
    }
}
