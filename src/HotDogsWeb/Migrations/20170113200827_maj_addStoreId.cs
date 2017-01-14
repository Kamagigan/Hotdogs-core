using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HotDogsWeb.Migrations
{
    public partial class maj_addStoreId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotDogs_Stores_StoreId",
                table: "HotDogs");

            migrationBuilder.RenameColumn(
                name: "ShortDescription",
                table: "HotDogs",
                newName: "Description");

            migrationBuilder.AlterColumn<int>(
                name: "StoreId",
                table: "HotDogs",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_HotDogs_Stores_StoreId",
                table: "HotDogs",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotDogs_Stores_StoreId",
                table: "HotDogs");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "HotDogs",
                newName: "ShortDescription");

            migrationBuilder.AlterColumn<int>(
                name: "StoreId",
                table: "HotDogs",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_HotDogs_Stores_StoreId",
                table: "HotDogs",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
