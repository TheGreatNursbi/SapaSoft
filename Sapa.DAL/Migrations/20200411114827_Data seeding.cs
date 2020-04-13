using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sapa.DAL.Migrations
{
    public partial class Dataseeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Builders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    BIN = table.Column<string>(type: "varchar(100)", nullable: false),
                    activitystartdate = table.Column<DateTime>(type: "datetime", nullable: false),
                    address = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    isdeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Builder", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Buildings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    height = table.Column<int>(type: "int", nullable: false),
                    floors = table.Column<int>(type: "int", nullable: false),
                    address = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    price = table.Column<int>(type: "int", nullable: false),
                    BuilderId = table.Column<int>(nullable: false),
                    isdeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Building", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Buildings_Builders_BuilderId",
                        column: x => x.BuilderId,
                        principalTable: "Builders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Builders",
                columns: new[] { "Id", "activitystartdate", "address", "BIN", "isdeleted", "name" },
                values: new object[] { 1, new DateTime(2020, 4, 11, 0, 0, 0, 0, DateTimeKind.Local), "Yrghyz 11", "1234-4567-7894-1236", false, "BI Group" });

            migrationBuilder.InsertData(
                table: "Buildings",
                columns: new[] { "Id", "address", "BuilderId", "floors", "height", "isdeleted", "name", "price" },
                values: new object[] { 1, "Imanbayeva", 1, 20, 100, false, "Shanyrak", 150000 });

            migrationBuilder.CreateIndex(
                name: "IX_Buildings_BuilderId",
                table: "Buildings",
                column: "BuilderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Buildings");

            migrationBuilder.DropTable(
                name: "Builders");
        }
    }
}
