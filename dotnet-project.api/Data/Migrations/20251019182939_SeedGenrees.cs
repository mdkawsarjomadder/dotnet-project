using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace dotnet_project.api.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedGenrees : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var unused6 = migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    var unused5 = table.PrimaryKey("PK_Genres", x => x.Id);
                });

            var unused4 = migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    GenreId = table.Column<int>(type: "INTEGER", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    ReleaseDate = table.Column<DateOnly>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    var unused3 = table.PrimaryKey("PK_Projects", x => x.Id);
                    var unused2 = table.ForeignKey(
                        name: "FK_Projects_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            var unused1 = migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Fighting" },
                    { 2, "Roleplaying" },
                    { 3, "Sports" },
                    { 4, "Racing" },
                    { 5, "Kids and family" }
                });

            var unused = migrationBuilder.CreateIndex(
                name: "IX_Projects_GenreId",
                table: "Projects",
                column: "GenreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var unused1 = migrationBuilder.DropTable(
                name: "Projects");

            var unused = migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
