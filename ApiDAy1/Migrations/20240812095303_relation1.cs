﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiDAy1.Migrations
{
    /// <inheritdoc />
    public partial class relation1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_categories_CAtegoryID",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "CAtegoryID",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_categories_CAtegoryID",
                table: "Products",
                column: "CAtegoryID",
                principalTable: "categories",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_categories_CAtegoryID",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "CAtegoryID",
                table: "Products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_categories_CAtegoryID",
                table: "Products",
                column: "CAtegoryID",
                principalTable: "categories",
                principalColumn: "id");
        }
    }
}
