using Microsoft.EntityFrameworkCore.Migrations;

namespace SuperMarketApi.Migrations
{
    public partial class updateunitablecompanyidcolumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Units",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Units_CompanyId",
                table: "Units",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Companies_CompanyId",
                table: "Units",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Units_Companies_CompanyId",
                table: "Units");

            migrationBuilder.DropIndex(
                name: "IX_Units_CompanyId",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Units");
        }
    }
}
