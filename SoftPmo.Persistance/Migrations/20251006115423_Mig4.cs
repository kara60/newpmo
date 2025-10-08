using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoftPmo.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class Mig4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "PRIORITY",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CODE_TEMPLATE_EntityType",
                table: "CODE_TEMPLATE",
                column: "EntityType");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CODE_TEMPLATE_EntityType",
                table: "CODE_TEMPLATE");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "PRIORITY");
        }
    }
}
