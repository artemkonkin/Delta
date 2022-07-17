using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DbContextLib.Migrations
{
    public partial class deleteCol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DirectoriesRows_Directories_DirectoryRowId",
                table: "DirectoriesRows");

            migrationBuilder.DropForeignKey(
                name: "FK_DirectoriesRowsColsData_DirectoriesRows_DirectoryRowId",
                table: "DirectoriesRowsColsData");

            migrationBuilder.DropIndex(
                name: "IX_DirectoriesRowsColsData_DirectoryRowId",
                table: "DirectoriesRowsColsData");

            migrationBuilder.DropIndex(
                name: "IX_DirectoriesRows_DirectoryRowId",
                table: "DirectoriesRows");

            migrationBuilder.DropColumn(
                name: "DirectoryRowId",
                table: "DirectoriesRows");

            migrationBuilder.AddColumn<Guid>(
                name: "DirectoryRowColId",
                table: "DirectoriesRowsColsData",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_DirectoriesRowsColsData_DirectoryRowColId",
                table: "DirectoriesRowsColsData",
                column: "DirectoryRowColId");

            migrationBuilder.CreateIndex(
                name: "IX_DirectoriesRows_DirectoryId",
                table: "DirectoriesRows",
                column: "DirectoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_DirectoriesRows_Directories_DirectoryId",
                table: "DirectoriesRows",
                column: "DirectoryId",
                principalTable: "Directories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DirectoriesRowsColsData_DirectoriesRows_DirectoryRowColId",
                table: "DirectoriesRowsColsData",
                column: "DirectoryRowColId",
                principalTable: "DirectoriesRows",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DirectoriesRows_Directories_DirectoryId",
                table: "DirectoriesRows");

            migrationBuilder.DropForeignKey(
                name: "FK_DirectoriesRowsColsData_DirectoriesRows_DirectoryRowColId",
                table: "DirectoriesRowsColsData");

            migrationBuilder.DropIndex(
                name: "IX_DirectoriesRowsColsData_DirectoryRowColId",
                table: "DirectoriesRowsColsData");

            migrationBuilder.DropIndex(
                name: "IX_DirectoriesRows_DirectoryId",
                table: "DirectoriesRows");

            migrationBuilder.DropColumn(
                name: "DirectoryRowColId",
                table: "DirectoriesRowsColsData");

            migrationBuilder.AddColumn<Guid>(
                name: "DirectoryRowId",
                table: "DirectoriesRows",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_DirectoriesRowsColsData_DirectoryRowId",
                table: "DirectoriesRowsColsData",
                column: "DirectoryRowId");

            migrationBuilder.CreateIndex(
                name: "IX_DirectoriesRows_DirectoryRowId",
                table: "DirectoriesRows",
                column: "DirectoryRowId");

            migrationBuilder.AddForeignKey(
                name: "FK_DirectoriesRows_Directories_DirectoryRowId",
                table: "DirectoriesRows",
                column: "DirectoryRowId",
                principalTable: "Directories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DirectoriesRowsColsData_DirectoriesRows_DirectoryRowId",
                table: "DirectoriesRowsColsData",
                column: "DirectoryRowId",
                principalTable: "DirectoriesRows",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
