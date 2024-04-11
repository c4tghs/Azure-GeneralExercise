using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AZGE.StockApi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ProductIdPropToegevoegd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                schema: "StockApi",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductId",
                schema: "StockApi",
                table: "Product");
        }
    }
}
