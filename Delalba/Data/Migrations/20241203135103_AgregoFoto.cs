using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Delalba.Migrations
{
    /// <inheritdoc />
    public partial class AgregoFoto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Foto",
                table: "Productos",
                type: "varbinary(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Foto",
                table: "Productos");
        }
    }
}
