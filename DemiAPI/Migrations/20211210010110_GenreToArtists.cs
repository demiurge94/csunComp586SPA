using Microsoft.EntityFrameworkCore.Migrations;

namespace DemiAPI.Migrations
{
    public partial class GenreToArtists : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artists_Genres_GenreId",
                table: "Artists");

            migrationBuilder.DropIndex(
                name: "IX_Artists_GenreId",
                table: "Artists");

            migrationBuilder.DropColumn(
                name: "Artist_genre_main",
                table: "Artists");

            migrationBuilder.DropColumn(
                name: "GenreId",
                table: "Artists");

            migrationBuilder.AddColumn<int>(
                name: "Artist_genre_id",
                table: "Artists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Artists_Artist_genre_id",
                table: "Artists",
                column: "Artist_genre_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Artists_Genres_Artist_genre_id",
                table: "Artists",
                column: "Artist_genre_id",
                principalTable: "Genres",
                principalColumn: "Genre_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artists_Genres_Artist_genre_id",
                table: "Artists");

            migrationBuilder.DropIndex(
                name: "IX_Artists_Artist_genre_id",
                table: "Artists");

            migrationBuilder.DropColumn(
                name: "Artist_genre_id",
                table: "Artists");

            migrationBuilder.AddColumn<string>(
                name: "Artist_genre_main",
                table: "Artists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GenreId",
                table: "Artists",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Artists_GenreId",
                table: "Artists",
                column: "GenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Artists_Genres_GenreId",
                table: "Artists",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Genre_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
