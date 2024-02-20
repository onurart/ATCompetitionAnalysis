using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompetitionAnalysis.Persistance.Migrations.CompanyDb
{
    /// <inheritdoc />
    public partial class ExplanationEklendi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Explanation",
                table: "ProductCustomerRelationship",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Explanation",
                table: "ProductCustomerRelationship");
        }
    }
}
