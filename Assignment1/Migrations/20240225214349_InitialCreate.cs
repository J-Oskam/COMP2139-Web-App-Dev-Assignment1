using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Assignment1.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookingType",
                columns: table => new
                {
                    BookingTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingType", x => x.BookingTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    FlightId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Airport = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Airline = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Availability = table.Column<int>(type: "int", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalPrice = table.Column<float>(type: "real", nullable: false),
                    ConfirmationNumber = table.Column<int>(type: "int", nullable: false),
                    userId = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    bookingTypeId = table.Column<int>(type: "int", nullable: false),
                    flightId = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    rentalId = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    hotelId = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.BookingId);
                    table.ForeignKey(
                        name: "FK_Bookings_BookingType_bookingTypeId",
                        column: x => x.bookingTypeId,
                        principalTable: "BookingType",
                        principalColumn: "BookingTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "FlightId", "Airline", "Airport", "ArrivalTime", "Availability", "DepartureTime", "Location", "Price", "Specifications" },
                values: new object[,]
                {
                    { 1, "Air Canada", "Toronto Pearson", new DateTime(2021, 8, 4, 23, 58, 30, 999, DateTimeKind.Unspecified), 99, new DateTime(2021, 8, 4, 23, 58, 30, 999, DateTimeKind.Unspecified), "Japan", 304, "Economy class" },
                    { 2, "United Airlines", "Toronto Pearson", new DateTime(2022, 8, 4, 23, 58, 30, 999, DateTimeKind.Unspecified), 5, new DateTime(2022, 8, 4, 23, 58, 30, 999, DateTimeKind.Unspecified), "USA", 200, "Economy class" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_bookingTypeId",
                table: "Bookings",
                column: "bookingTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.DropTable(
                name: "BookingType");
        }
    }
}
