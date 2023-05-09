using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SteamCopy.Migrations
{
    /// <inheritdoc />
    public partial class InitalCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SteamGames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SteamGames", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SteamGameDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SteamGameId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    Rating = table.Column<decimal>(type: "decimal(2,1)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OverallQuality = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SteamGameDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SteamGameDetails_SteamGames_SteamGameId",
                        column: x => x.SteamGameId,
                        principalTable: "SteamGames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SteamGameDetails_SteamGameId",
                table: "SteamGameDetails",
                column: "SteamGameId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SteamGameDetails");

            migrationBuilder.DropTable(
                name: "SteamGames");
        }
    }
}
