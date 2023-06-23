using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace P1_HangfireProject.Core.Migrations
{
    /// <inheritdoc />
    public partial class ChangedExchangeRateModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TRY",
                table: "ExchangeRates");

            migrationBuilder.AddColumn<int>(
                name: "RatesId",
                table: "ExchangeRates",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Rates",
                columns: table => new
                {
                    RatesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TRY = table.Column<decimal>(type: "decimal(6,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rates", x => x.RatesId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExchangeRates_RatesId",
                table: "ExchangeRates",
                column: "RatesId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExchangeRates_Rates_RatesId",
                table: "ExchangeRates",
                column: "RatesId",
                principalTable: "Rates",
                principalColumn: "RatesId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExchangeRates_Rates_RatesId",
                table: "ExchangeRates");

            migrationBuilder.DropTable(
                name: "Rates");

            migrationBuilder.DropIndex(
                name: "IX_ExchangeRates_RatesId",
                table: "ExchangeRates");

            migrationBuilder.DropColumn(
                name: "RatesId",
                table: "ExchangeRates");

            migrationBuilder.AddColumn<decimal>(
                name: "TRY",
                table: "ExchangeRates",
                type: "decimal(6,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
