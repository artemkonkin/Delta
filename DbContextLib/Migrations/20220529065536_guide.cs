using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DbContextLib.Migrations
{
    public partial class guide : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GuidesLists",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuidesLists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Guides",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    GuideListId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guides", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Guides_GuidesLists_GuideListId",
                        column: x => x.GuideListId,
                        principalTable: "GuidesLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GuidesRows",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GuideId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GuideRowId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuidesRows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GuidesRows_Guides_GuideRowId",
                        column: x => x.GuideRowId,
                        principalTable: "Guides",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GuidesCols",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    DataType = table.Column<int>(type: "int", nullable: false),
                    GuideRowId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuidesCols", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GuidesCols_GuidesRows_GuideRowId",
                        column: x => x.GuideRowId,
                        principalTable: "GuidesRows",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GuidesRowsColsData",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GuideRowId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GuideColId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<object>(type: "sql_variant", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuidesRowsColsData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GuidesRowsColsData_GuidesCols_GuideColId",
                        column: x => x.GuideColId,
                        principalTable: "GuidesCols",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GuidesRowsColsData_GuidesRows_GuideRowId",
                        column: x => x.GuideRowId,
                        principalTable: "GuidesRows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Guides_GuideListId",
                table: "Guides",
                column: "GuideListId");

            migrationBuilder.CreateIndex(
                name: "IX_GuidesCols_GuideRowId",
                table: "GuidesCols",
                column: "GuideRowId");

            migrationBuilder.CreateIndex(
                name: "IX_GuidesRows_GuideRowId",
                table: "GuidesRows",
                column: "GuideRowId");

            migrationBuilder.CreateIndex(
                name: "IX_GuidesRowsColsData_GuideColId",
                table: "GuidesRowsColsData",
                column: "GuideColId");

            migrationBuilder.CreateIndex(
                name: "IX_GuidesRowsColsData_GuideRowId",
                table: "GuidesRowsColsData",
                column: "GuideRowId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GuidesRowsColsData");

            migrationBuilder.DropTable(
                name: "GuidesCols");

            migrationBuilder.DropTable(
                name: "GuidesRows");

            migrationBuilder.DropTable(
                name: "Guides");

            migrationBuilder.DropTable(
                name: "GuidesLists");
        }
    }
}
