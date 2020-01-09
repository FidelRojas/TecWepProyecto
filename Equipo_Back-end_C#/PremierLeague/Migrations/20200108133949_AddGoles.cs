using Microsoft.EntityFrameworkCore.Migrations;

namespace PremierLeague.Migrations
{
    public partial class AddGoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "goles",
                table: "Jugadores",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "goles",
                table: "Jugadores");
        }
    }
}
