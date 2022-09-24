using Microsoft.EntityFrameworkCore.Migrations;

namespace SuperMarketApi.Migrations
{
    public partial class updatepurchseliststoreid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StoreId",
                table: "PurchaseLists",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseLists_StoreId",
                table: "PurchaseLists",
                column: "StoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseLists_Stores_StoreId",
                table: "PurchaseLists",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseLists_Stores_StoreId",
                table: "PurchaseLists");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseLists_StoreId",
                table: "PurchaseLists");

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "PurchaseLists");
        }
    }
}
