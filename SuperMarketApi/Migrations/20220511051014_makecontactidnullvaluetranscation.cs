using Microsoft.EntityFrameworkCore.Migrations;

namespace SuperMarketApi.Migrations
{
    public partial class makecontactidnullvaluetranscation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Transactions_Contacts_ContactId",
            //    table: "Transactions");

            migrationBuilder.AlterColumn<int>(
                name: "ContactId",
                table: "Transactions",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Contacts_ContactId",
                table: "Transactions",
                column: "ContactId",
                principalTable: "Contacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Contacts_ContactId",
                table: "Transactions");

            migrationBuilder.AlterColumn<int>(
                name: "ContactId",
                table: "Transactions",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Contacts_ContactId",
                table: "Transactions",
                column: "ContactId",
                principalTable: "Contacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
