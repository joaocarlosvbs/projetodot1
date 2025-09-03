using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projetodot1.Migrations
{
    /// <inheritdoc />
    public partial class correcaolivroscs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Livros",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Livros");
        }
    }
}
