using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Assignment1.Migrations
{
    /// <inheritdoc />
    public partial class FlightMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    FlightId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Airport = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Airline = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Availability = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    DepartureTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ArrivalTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Specifications = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.FlightId);
                });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "FlightId", "Airline", "Airport", "ArrivalTime", "Availability", "DepartureTime", "Location", "Price", "Specifications" },
                values: new object[,]
                {
                    { 1, "Air Canada", "Toronto Pearson", new DateTime(2021, 8, 4, 23, 58, 30, 999, DateTimeKind.Unspecified), "99", new DateTime(2021, 8, 4, 23, 58, 30, 999, DateTimeKind.Unspecified), "Japan", 304, "Economy class" },
                    { 2, "United Airlines", "Toronto Pearson", new DateTime(2022, 8, 4, 23, 58, 30, 999, DateTimeKind.Unspecified), "5", new DateTime(2022, 8, 4, 23, 58, 30, 999, DateTimeKind.Unspecified), "USA", 200, "Economy class" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flights");
        }
    }
}
