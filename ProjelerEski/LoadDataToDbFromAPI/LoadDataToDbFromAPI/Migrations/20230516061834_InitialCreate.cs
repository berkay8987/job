using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoadDataToDbFromAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WeatherInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Localtime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Temp_c = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    Feelslike_c = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    Humidity = table.Column<int>(type: "int", nullable: false),
                    Wind_kph = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    WeatherConditionText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IconUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherInfos", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeatherInfos");
        }
    }
}
