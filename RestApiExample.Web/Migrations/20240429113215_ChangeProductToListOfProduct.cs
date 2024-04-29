using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestApiExample.Web.Migrations
{
    /// <inheritdoc />
    public partial class ChangeProductToListOfProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_order_product_ProductId",
                table: "order");

            migrationBuilder.DropIndex(
                name: "IX_order_ProductId",
                table: "order");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "order");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "product",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_product_OrderId",
                table: "product",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_product_order_OrderId",
                table: "product",
                column: "OrderId",
                principalTable: "order",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_product_order_OrderId",
                table: "product");

            migrationBuilder.DropIndex(
                name: "IX_product_OrderId",
                table: "product");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "product");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "order",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_order_ProductId",
                table: "order",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_order_product_ProductId",
                table: "order",
                column: "ProductId",
                principalTable: "product",
                principalColumn: "Id");
        }
    }
}
