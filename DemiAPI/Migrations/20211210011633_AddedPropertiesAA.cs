using Microsoft.EntityFrameworkCore.Migrations;

namespace DemiAPI.Migrations
{
    public partial class AddedPropertiesAA : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Artist_Bass",
                table: "Artists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Artist_Drums",
                table: "Artists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Artist_Guitar_one",
                table: "Artists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Artist_Guitar_two",
                table: "Artists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Artist_Singer",
                table: "Artists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Album_Release_Number",
                table: "Albums",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Album_sales",
                table: "Albums",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Artist_Bass",
                table: "Artists");

            migrationBuilder.DropColumn(
                name: "Artist_Drums",
                table: "Artists");

            migrationBuilder.DropColumn(
                name: "Artist_Guitar_one",
                table: "Artists");

            migrationBuilder.DropColumn(
                name: "Artist_Guitar_two",
                table: "Artists");

            migrationBuilder.DropColumn(
                name: "Artist_Singer",
                table: "Artists");

            migrationBuilder.DropColumn(
                name: "Album_Release_Number",
                table: "Albums");

            migrationBuilder.DropColumn(
                name: "Album_sales",
                table: "Albums");
        }
    }
}
