using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoadDataToDbFromAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddedSoftDeleteVariables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "isActive",
                table: "WeatherInfos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "isDeleted",
                table: "WeatherInfos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isActive",
                table: "WeatherInfos");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "WeatherInfos");
        }
    }
}
