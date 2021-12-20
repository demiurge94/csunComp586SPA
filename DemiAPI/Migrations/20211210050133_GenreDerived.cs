using Microsoft.EntityFrameworkCore.Migrations;

namespace DemiAPI.Migrations
{
    public partial class GenreDerived : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Genre_decade",
                table: "Genres",
                newName: "Genre_emergence_year");

            migrationBuilder.AddColumn<int>(
                name: "Derived_from",
                table: "Genres",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Derived_from",
                table: "Genres");

            migrationBuilder.RenameColumn(
                name: "Genre_emergence_year",
                table: "Genres",
                newName: "Genre_decade");
        }
    }
}
