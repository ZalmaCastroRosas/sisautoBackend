using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DB.Migrations
{
    /// <inheritdoc />
    public partial class segunda_version : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Clientes_PaisID",
                table: "Clientes",
                column: "PaisID");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Paises_PaisID",
                table: "Clientes",
                column: "PaisID",
                principalTable: "Paises",
                principalColumn: "PaisID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Paises_PaisID",
                table: "Clientes");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_PaisID",
                table: "Clientes");
        }
    }
}
