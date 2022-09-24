using Microsoft.EntityFrameworkCore.Migrations;

namespace SuperMarketApi.Migrations
{
    public partial class addStockBatchIdcolumnonOrderitem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StockBatchId",
                table: "OrderItemDetails",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderItemDetails_StockBatchId",
                table: "OrderItemDetails",
                column: "StockBatchId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItemDetails_StockBatches_StockBatchId",
                table: "OrderItemDetails",
                column: "StockBatchId",
                principalTable: "StockBatches",
                principalColumn: "StockBatchId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItemDetails_StockBatches_StockBatchId",
                table: "OrderItemDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderItemDetails_StockBatchId",
                table: "OrderItemDetails");

            migrationBuilder.DropColumn(
                name: "StockBatchId",
                table: "OrderItemDetails");
        }
    }
}
