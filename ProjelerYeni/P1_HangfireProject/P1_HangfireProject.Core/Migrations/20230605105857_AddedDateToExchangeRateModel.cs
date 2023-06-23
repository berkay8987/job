using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace P1_HangfireProject.Core.Migrations
{
    /// <inheritdoc />
    public partial class AddedDateToExchangeRateModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "ExchangeRates",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "ExchangeRates");
        }
    }
}
