using Microsoft.EntityFrameworkCore.Migrations;

namespace DemiAPI.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Artist_genre_main",
                table: "Artists",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artists_Genres_Artist_genre_main",
                table: "Artists");

            migrationBuilder.DropIndex(
                name: "IX_Artists_Artist_genre_main",
                table: "Artists");

            migrationBuilder.AlterColumn<string>(
                name: "Artist_genre_main",
                table: "Artists",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
