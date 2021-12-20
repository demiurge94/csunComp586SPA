using Microsoft.EntityFrameworkCore.Migrations;

namespace DemiAPI.Migrations
{
    public partial class oneToMany1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artists_Genres_Artist_genre_main",
                table: "Artists");

            migrationBuilder.DropIndex(
                name: "IX_Artists_Artist_genre_main",
                table: "Artists");

            migrationBuilder.DropColumn(
                name: "Artist_genre_main",
                table: "Artists");

            migrationBuilder.AddForeignKey(
                name: "FK_Artists_Genres_Artist_id",
                table: "Artists",
                column: "Artist_id",
                principalTable: "Genres",
                principalColumn: "Genre_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artists_Genres_Artist_id",
                table: "Artists");

            migrationBuilder.AddColumn<int>(
                name: "Artist_genre_main",
                table: "Artists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Artists_Artist_genre_main",
                table: "Artists",
                column: "Artist_genre_main");

            migrationBuilder.AddForeignKey(
                name: "FK_Artists_Genres_Artist_genre_main",
                table: "Artists",
                column: "Artist_genre_main",
                principalTable: "Genres",
                principalColumn: "Genre_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
