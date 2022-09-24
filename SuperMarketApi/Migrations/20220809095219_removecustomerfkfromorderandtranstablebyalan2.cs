using Microsoft.EntityFrameworkCore.Migrations;

namespace SuperMarketApi.Migrations
{
    public partial class removecustomerfkfromorderandtranstablebyalan2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_CustomerAddress_Customers_CustomerId",
            //    table: "CustomerAddress");

            //migrationBuilder.DropIndex(
            //    name: "IX_CustomerAddress_CustomerId",
            //    table: "CustomerAddress");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateIndex(
            //    name: "IX_CustomerAddress_CustomerId",
            //    table: "CustomerAddress",
            //    column: "CustomerId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_CustomerAddress_Customers_CustomerId",
            //    table: "CustomerAddress",
            //    column: "CustomerId",
            //    principalTable: "Customers",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
        }
    }
}
