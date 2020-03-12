using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ConsoleApp1.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mains",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mains", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true),
                    CountryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Details",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true),
                    ValueDecimal = table.Column<decimal>(nullable: true),
                    ValueDateTime = table.Column<DateTime>(nullable: true),
                    ValueInt = table.Column<int>(nullable: true),
                    ValueString = table.Column<string>(nullable: true),
                    CityId = table.Column<int>(nullable: true),
                    MainId = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    ValueChildInt = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Details", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Details_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Details_Mains_MainId",
                        column: x => x.MainId,
                        principalTable: "Mains",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Ukraine" },
                    { 2, "Russia" },
                    { 3, "USA" }
                });

            migrationBuilder.InsertData(
                table: "Mains",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Main-1" },
                    { 2, "Main-2" },
                    { 3, "Main-3" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Kyiv" },
                    { 2, 1, "Charkov" },
                    { 3, 1, "Odessa" },
                    { 4, 2, "Moscow" },
                    { 5, 2, "StPetersburg" },
                    { 6, 3, "Washington" },
                    { 7, 3, "Los-Angeles" },
                    { 8, 3, "New York" }
                });

            migrationBuilder.InsertData(
                table: "Details",
                columns: new[] { "Id", "CityId", "Discriminator", "MainId", "Name", "ValueDateTime", "ValueDecimal", "ValueInt", "ValueString", "ValueChildInt" },
                values: new object[] { 4, 1, "DetailChild", 2, "DetailChild-1", new DateTime(2020, 1, 2, 10, 0, 0, 0, DateTimeKind.Unspecified), 11.2m, 18, "Крокодилы-бегемоты и зеленый попугай", 1 });

            migrationBuilder.InsertData(
                table: "Details",
                columns: new[] { "Id", "CityId", "Discriminator", "MainId", "Name", "ValueDateTime", "ValueDecimal", "ValueInt", "ValueString" },
                values: new object[,]
                {
                    { 1, 4, "Detail", 1, "Detail-1", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10.12m, 12, "В лесу родилась ёлочка в лесу она росла" },
                    { 2, 4, "Detail", 1, "Detail-2", new DateTime(2010, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 34.56m, 14, "Зимой и летом стройная" },
                    { 3, 4, "Detail", 1, "Detail-3", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 78.9m, 16, "Зеленая была" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Details_CityId",
                table: "Details",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Details_MainId",
                table: "Details",
                column: "MainId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Details");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Mains");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
