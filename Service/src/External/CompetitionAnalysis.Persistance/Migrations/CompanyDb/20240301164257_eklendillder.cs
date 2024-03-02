﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompetitionAnalysis.Persistance.Migrations.CompanyDb
{
    /// <inheritdoc />
    public partial class eklendillder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "ProductCustomerRelationship");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "ProductCustomerRelationship",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
