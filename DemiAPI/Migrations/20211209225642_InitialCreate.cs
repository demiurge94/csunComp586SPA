using Microsoft.EntityFrameworkCore.Migrations;

namespace DemiAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /* migrationBuilder.CreateTable(
                name: "Albums",
                columns: table => new
                {
                    Album_id = table.Column<int>(type: "int", nullable: false),
                    Album_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Album_year = table.Column<int>(type: "int", nullable: true),
                    Album_Artist = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albums", x => x.Album_id);
                });

            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    Artist_id = table.Column<int>(type: "int", nullable: false),
                    Artist_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Artist_genre_main = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Artist_bio = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.Artist_id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Genre_id = table.Column<int>(type: "int", nullable: false),
                    Genre_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Genre_decade = table.Column<int>(type: "int", nullable: true),
                    Genre_description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Genre_id);
                });*/
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Albums");

            migrationBuilder.DropTable(
                name: "Artists");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
