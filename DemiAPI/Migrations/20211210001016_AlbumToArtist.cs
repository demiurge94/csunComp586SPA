using Microsoft.EntityFrameworkCore.Migrations;

namespace DemiAPI.Migrations
{
    public partial class AlbumToArtist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Album_Artist",
                table: "Albums",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Albums_Album_Artist",
                table: "Albums",
                column: "Album_Artist");

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_Artists_Album_Artist",
                table: "Albums",
                column: "Album_Artist",
                principalTable: "Artists",
                principalColumn: "Artist_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Albums_Artists_Album_Artist",
                table: "Albums");

            migrationBuilder.DropIndex(
                name: "IX_Albums_Album_Artist",
                table: "Albums");

            migrationBuilder.AlterColumn<string>(
                name: "Album_Artist",
                table: "Albums",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
