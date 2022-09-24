using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SuperMarketApi.Migrations
{
    public partial class updatepurchselishtableordereddate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ReceviedDate",
                table: "PurchaseLists",
                type: "Date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReceviedDate",
                table: "PurchaseLists");
        }
    }
}
