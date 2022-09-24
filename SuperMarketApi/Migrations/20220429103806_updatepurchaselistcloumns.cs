using Microsoft.EntityFrameworkCore.Migrations;

namespace SuperMarketApi.Migrations
{
    public partial class updatepurchaselistcloumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Delivery",
                table: "PurchaseLists",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UnitId",
                table: "PurchaseLists",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Warranty",
                table: "PurchaseLists",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseLists_UnitId",
                table: "PurchaseLists",
                column: "UnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseLists_Units_UnitId",
                table: "PurchaseLists",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseLists_Units_UnitId",
                table: "PurchaseLists");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseLists_UnitId",
                table: "PurchaseLists");

            migrationBuilder.DropColumn(
                name: "Delivery",
                table: "PurchaseLists");

            migrationBuilder.DropColumn(
                name: "UnitId",
                table: "PurchaseLists");

            migrationBuilder.DropColumn(
                name: "Warranty",
                table: "PurchaseLists");
        }
    }
}
