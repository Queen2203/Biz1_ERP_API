using Microsoft.EntityFrameworkCore.Migrations;

namespace SuperMarketApi.Migrations
{
    public partial class removecustomerfkfromorderandtranstablebyalan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
        //    migrationBuilder.DropForeignKey(
        //        name: "FK_Orders_Customers_CustomerId",
        //        table: "Orders");

        //    migrationBuilder.DropForeignKey(
        //        name: "FK_Transactions_Customers_CustomerId",
        //        table: "Transactions");

        //    migrationBuilder.DropIndex(
        //        name: "IX_Transactions_CustomerId",
        //        table: "Transactions");

        //    migrationBuilder.DropIndex(
        //        name: "IX_Orders_CustomerId",
        //        table: "Orders");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateIndex(
            //    name: "IX_Transactions_CustomerId",
            //    table: "Transactions",
            //    column: "CustomerId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Orders_CustomerId",
            //    table: "Orders",
            //    column: "CustomerId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Orders_Customers_CustomerId",
            //    table: "Orders",
            //    column: "CustomerId",
            //    principalTable: "Customers",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Transactions_Customers_CustomerId",
            //    table: "Transactions",
            //    column: "CustomerId",
            //    principalTable: "Customers",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);
        }
    }
}
