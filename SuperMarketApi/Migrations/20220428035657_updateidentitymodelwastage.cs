using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SuperMarketApi.Migrations
{
    public partial class updateidentitymodelwastage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Wastages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductId = table.Column<int>(nullable: false),
                    StoreId = table.Column<int>(nullable: true),
                    CompanyId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: true),
                    WastageDate = table.Column<DateTime>(type: "Date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wastages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wastages_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Wastages_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Wastages_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Wastages_CompanyId",
                table: "Wastages",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Wastages_ProductId",
                table: "Wastages",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Wastages_StoreId",
                table: "Wastages",
                column: "StoreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Wastages");
        }
    }
}
