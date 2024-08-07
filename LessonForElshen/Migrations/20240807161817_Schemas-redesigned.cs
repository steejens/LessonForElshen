using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LessonForElshen.Migrations
{
    /// <inheritdoc />
    public partial class Schemasredesigned : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "prdSchema");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Products",
                newSchema: "prdSchema");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Categories",
                newSchema: "prdSchema");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Products",
                schema: "prdSchema",
                newName: "Products");

            migrationBuilder.RenameTable(
                name: "Categories",
                schema: "prdSchema",
                newName: "Categories");
        }
    }
}
