using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Delalba.Migrations
{
    /// <inheritdoc />
    public partial class Activado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Activado",
                table: "Productos",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Activado",
                table: "Productos");
        }
    }
}
