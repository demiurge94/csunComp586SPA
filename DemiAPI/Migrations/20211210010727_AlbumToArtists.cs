using Microsoft.EntityFrameworkCore.Migrations;

namespace DemiAPI.Migrations
{
    public partial class AlbumToArtists : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Albums_Artists_Album_Artist",
                table: "Albums");

            migrationBuilder.RenameColumn(
                name: "Album_Artist",
                table: "Albums",
                newName: "Album_Artist_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Albums_Album_Artist",
                table: "Albums",
                newName: "IX_Albums_Album_Artist_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_Artists_Album_Artist_Id",
                table: "Albums",
                column: "Album_Artist_Id",
                principalTable: "Artists",
                principalColumn: "Artist_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Albums_Artists_Album_Artist_Id",
                table: "Albums");

            migrationBuilder.RenameColumn(
                name: "Album_Artist_Id",
                table: "Albums",
                newName: "Album_Artist");

            migrationBuilder.RenameIndex(
                name: "IX_Albums_Album_Artist_Id",
                table: "Albums",
                newName: "IX_Albums_Album_Artist");

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_Artists_Album_Artist",
                table: "Albums",
                column: "Album_Artist",
                principalTable: "Artists",
                principalColumn: "Artist_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
