using Microsoft.EntityFrameworkCore.Migrations;

namespace DemiAPI.Migrations
{
    public partial class AlbumLabelAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Album_label",
                table: "Albums",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Album_label",
                table: "Albums");
        }
    }
}
