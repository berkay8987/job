﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace P1_HangfireProject.Core.Migrations
{
    /// <inheritdoc />
    public partial class AddedBalanceToCustomerModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Balance",
                table: "Customers",
                type: "decimal(6,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Balance",
                table: "Customers");
        }
    }
}
