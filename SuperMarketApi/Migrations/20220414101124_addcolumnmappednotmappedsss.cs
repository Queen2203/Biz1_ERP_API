﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace SuperMarketApi.Migrations
{
    public partial class addcolumnmappednotmappedsss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<int>(
            //    name: "CompanyId",
            //    table: "UserStores",
            //    nullable: false,
            //    defaultValue: 0);

            //migrationBuilder.CreateIndex(
            //    name: "IX_UserStores_CompanyId",
            //    table: "UserStores",
            //    column: "CompanyId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_UserStores_Companies_CompanyId",
            //    table: "UserStores",
            //    column: "CompanyId",
            //    principalTable: "Companies",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_UserStores_Companies_CompanyId",
            //    table: "UserStores");

            //migrationBuilder.DropIndex(
            //    name: "IX_UserStores_CompanyId",
            //    table: "UserStores");

            //migrationBuilder.DropColumn(
            //    name: "CompanyId",
            //    table: "UserStores");
        }
    }
}
