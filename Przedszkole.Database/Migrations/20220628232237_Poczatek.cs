using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Przedszkole.Database.Migrations
{
    public partial class Poczatek : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rodzice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImieMatki = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NazwiskoMatki = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImieOjca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NazwiskoOjca = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rodzice", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Wychowawcy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wychowawcy", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dzieci",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RodziceId = table.Column<int>(type: "int", nullable: false),
                    WychowawcaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dzieci", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dzieci_Rodzice_RodziceId",
                        column: x => x.RodziceId,
                        principalTable: "Rodzice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Dzieci_Wychowawcy_WychowawcaId",
                        column: x => x.WychowawcaId,
                        principalTable: "Wychowawcy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Obecnosci",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DzieckoId = table.Column<int>(type: "int", nullable: false),
                    Obecny = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Obecnosci", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Obecnosci_Dzieci_DzieckoId",
                        column: x => x.DzieckoId,
                        principalTable: "Dzieci",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dzieci_RodziceId",
                table: "Dzieci",
                column: "RodziceId");

            migrationBuilder.CreateIndex(
                name: "IX_Dzieci_WychowawcaId",
                table: "Dzieci",
                column: "WychowawcaId");

            migrationBuilder.CreateIndex(
                name: "IX_Obecnosci_DzieckoId",
                table: "Obecnosci",
                column: "DzieckoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Obecnosci");

            migrationBuilder.DropTable(
                name: "Dzieci");

            migrationBuilder.DropTable(
                name: "Rodzice");

            migrationBuilder.DropTable(
                name: "Wychowawcy");
        }
    }
}
