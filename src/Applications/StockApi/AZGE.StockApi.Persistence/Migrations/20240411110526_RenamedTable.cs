using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AZGE.StockApi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RenamedTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stock_Product_ProductId",
                schema: "StockApi",
                table: "Stock");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                schema: "StockApi",
                table: "Product");

            migrationBuilder.RenameTable(
                name: "Product",
                schema: "StockApi",
                newName: "$StockProduct",
                newSchema: "StockApi");

            migrationBuilder.AddPrimaryKey(
                name: "PK_$StockProduct",
                schema: "StockApi",
                table: "$StockProduct",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Stock_$StockProduct_ProductId",
                schema: "StockApi",
                table: "Stock",
                column: "ProductId",
                principalSchema: "StockApi",
                principalTable: "$StockProduct",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stock_$StockProduct_ProductId",
                schema: "StockApi",
                table: "Stock");

            migrationBuilder.DropPrimaryKey(
                name: "PK_$StockProduct",
                schema: "StockApi",
                table: "$StockProduct");

            migrationBuilder.RenameTable(
                name: "$StockProduct",
                schema: "StockApi",
                newName: "Product",
                newSchema: "StockApi");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                schema: "StockApi",
                table: "Product",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Stock_Product_ProductId",
                schema: "StockApi",
                table: "Stock",
                column: "ProductId",
                principalSchema: "StockApi",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
