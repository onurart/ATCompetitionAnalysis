using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompetitionAnalysis.Persistance.Migrations.CompanyDb
{
    /// <inheritdoc />
    public partial class SpeciesesEklendi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Specieses",
                table: "ProductCustomerRelationship",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Specieses",
                table: "ProductCustomerRelationship");
        }
    }
}
