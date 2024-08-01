using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LessonForElshen.Migrations
{
    /// <inheritdoc />
    public partial class ProductstockCountchangedtocount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StockCount",
                table: "Products",
                newName: "Count");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Count",
                table: "Products",
                newName: "StockCount");
        }
    }
}
