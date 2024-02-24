using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompetitionAnalysis.Persistance.Migrations.CompanyDb
{
    /// <inheritdoc />
    public partial class productKaldirildi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCustomerRelationship_Products_ProductId",
                table: "ProductCustomerRelationship");

            migrationBuilder.DropIndex(
                name: "IX_ProductCustomerRelationship_ProductId",
                table: "ProductCustomerRelationship");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "ProductCustomerRelationship");

            migrationBuilder.DropColumn(
                name: "ProductId",
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

            migrationBuilder.AddColumn<string>(
                name: "ProductId",
                table: "ProductCustomerRelationship",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductCustomerRelationship_ProductId",
                table: "ProductCustomerRelationship",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCustomerRelationship_Products_ProductId",
                table: "ProductCustomerRelationship",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");
        }
    }
}
