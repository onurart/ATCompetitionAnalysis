using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompetitionAnalysis.Persistance.Migrations.CompanyDb
{
    /// <inheritdoc />
    public partial class eklendiler : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "CurrencyDolor",
                table: "ProductCustomerRelationship",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "CurrencyEuro",
                table: "ProductCustomerRelationship",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "CurrencyTl",
                table: "ProductCustomerRelationship",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "ProductCustomerRelationship",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "RakipDolor",
                table: "ProductCustomerRelationship",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "RakipEuro",
                table: "ProductCustomerRelationship",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "RakipTl",
                table: "ProductCustomerRelationship",
                type: "decimal(18,2)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrencyDolor",
                table: "ProductCustomerRelationship");

            migrationBuilder.DropColumn(
                name: "CurrencyEuro",
                table: "ProductCustomerRelationship");

            migrationBuilder.DropColumn(
                name: "CurrencyTl",
                table: "ProductCustomerRelationship");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "ProductCustomerRelationship");

            migrationBuilder.DropColumn(
                name: "RakipDolor",
                table: "ProductCustomerRelationship");

            migrationBuilder.DropColumn(
                name: "RakipEuro",
                table: "ProductCustomerRelationship");

            migrationBuilder.DropColumn(
                name: "RakipTl",
                table: "ProductCustomerRelationship");
        }
    }
}
