using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestaoResidencialMVC.Migrations
{
    /// <inheritdoc />
    public partial class nm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Lancamentos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Lancamentos");
        }
    }
}
