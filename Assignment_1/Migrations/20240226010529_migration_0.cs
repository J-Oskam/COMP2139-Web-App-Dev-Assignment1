using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Assignment_1.Migrations
{
    /// <inheritdoc />
    public partial class migration_0 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookingTypes",
                columns: table => new
                {
                    BookingTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingTypes", x => x.BookingTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsGuest = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    CityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.CityId);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    HotelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotelName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    Pricing = table.Column<double>(type: "float", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: true),
                    AvailableRooms = table.Column<int>(type: "int", nullable: false),
                    Amenities = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.HotelId);
                    table.ForeignKey(
                        name: "FK_Hotels_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Cascade);
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
                    TotalPrice = table.Column<double>(type: "float", nullable: false),
                    ConfirmationNumber = table.Column<int>(type: "int", nullable: false),
                    userId = table.Column<int>(type: "int", maxLength: 10, nullable: true),
                    hotelId = table.Column<int>(type: "int", nullable: true),
                    flightId = table.Column<int>(type: "int", nullable: true),
                    cityId = table.Column<int>(type: "int", nullable: true),
                    rentalId = table.Column<int>(type: "int", nullable: true),
                    bookingTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.BookingId);
                    table.ForeignKey(
                        name: "FK_Bookings_BookingTypes_bookingTypeId",
                        column: x => x.bookingTypeId,
                        principalTable: "BookingTypes",
                        principalColumn: "BookingTypeId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Bookings_Cities_cityId",
                        column: x => x.cityId,
                        principalTable: "Cities",
                        principalColumn: "CityId");
                    table.ForeignKey(
                        name: "FK_Bookings_Hotels_hotelId",
                        column: x => x.hotelId,
                        principalTable: "Hotels",
                        principalColumn: "HotelId");
                    table.ForeignKey(
                        name: "FK_Bookings_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "CarRentals",
                columns: table => new
                {
                    RentalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RentalCompany = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Availability = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    CarYear = table.Column<int>(type: "int", nullable: false),
                    CarMake = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarModel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Specifications = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookingId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarRentals", x => x.RentalId);
                    table.ForeignKey(
                        name: "FK_CarRentals_Bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Bookings",
                        principalColumn: "BookingId");
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
                    Specifications = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookingId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.FlightId);
                    table.ForeignKey(
                        name: "FK_Flights_Bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Bookings",
                        principalColumn: "BookingId");
                });

            migrationBuilder.InsertData(
                table: "BookingTypes",
                columns: new[] { "BookingTypeId", "TypeName" },
                values: new object[] { 1, "Hotel" });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "BookingId", "BookingDate", "ConfirmationNumber", "EndDate", "StartDate", "TotalPrice", "bookingTypeId", "cityId", "flightId", "hotelId", "rentalId", "userId" },
                values: new object[,]
                {
                    { 18, new DateTime(2024, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 45875, new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 850.0, 1, null, null, null, null, null },
                    { 51, new DateTime(2024, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 45876, new DateTime(2025, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 760.5, 1, null, null, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryId", "CountryName" },
                values: new object[,]
                {
                    { 1, "United States" },
                    { 2, "Canada" },
                    { 3, "Mexico" }
                });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "FlightId", "Airline", "Airport", "ArrivalTime", "Availability", "BookingId", "DepartureTime", "Location", "Price", "Specifications" },
                values: new object[,]
                {
                    { 1, "Air Canada", "Toronto Pearson", new DateTime(2021, 8, 4, 23, 58, 30, 999, DateTimeKind.Unspecified), 99, null, new DateTime(2021, 8, 4, 23, 58, 30, 999, DateTimeKind.Unspecified), "Japan", 304, "Economy class" },
                    { 2, "United Airlines", "Toronto Pearson", new DateTime(2022, 8, 4, 23, 58, 30, 999, DateTimeKind.Unspecified), 5, null, new DateTime(2022, 8, 4, 23, 58, 30, 999, DateTimeKind.Unspecified), "USA", 200, "Economy class" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "CityId", "CityName", "CountryId" },
                values: new object[,]
                {
                    { 1, "New York", 1 },
                    { 2, "Los Angeles", 1 },
                    { 3, "Chicago", 1 },
                    { 4, "Houston", 1 },
                    { 5, "Phoenix", 1 },
                    { 6, "Philadelphia", 1 },
                    { 7, "San Antonio", 1 },
                    { 8, "San Diego", 1 },
                    { 9, "Dallas", 1 },
                    { 10, "San Jose", 1 },
                    { 11, "Toronto", 2 },
                    { 12, "Montreal", 2 },
                    { 13, "Vancouver", 2 },
                    { 14, "Calgary", 2 },
                    { 15, "Edmonton", 2 },
                    { 16, "Ottawa", 2 },
                    { 17, "Winnipeg", 2 },
                    { 18, "Quebec City", 2 },
                    { 19, "Hamilton", 2 },
                    { 20, "Kitchener", 2 },
                    { 21, "Mexico City", 3 },
                    { 22, "Guadalajara", 3 },
                    { 23, "Monterrey", 3 },
                    { 24, "Puebla", 3 },
                    { 25, "Toluca", 3 },
                    { 26, "Tijuana", 3 },
                    { 27, "León", 3 },
                    { 28, "Ciudad Juárez", 3 },
                    { 29, "Torreón", 3 },
                    { 30, "San Luis Potosí", 3 }
                });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "HotelId", "Amenities", "AvailableRooms", "CityId", "HotelName", "Pricing", "Rating" },
                values: new object[,]
                {
                    { 1, "Pool, Free WiFi, Gym", 75, 2, "Hotel California", 150.0, 5 },
                    { 2, "Free WiFi, Gym", 350, 1, "The Big Apple Hotel", 200.0, 4 },
                    { 3, "Free WiFi, Gym, Hot Tub, Sauna, Pool", 950, 8, "The Estate Hotel", 175.0, 4 },
                    { 4, "Free WiFi, Gym, Pool, Sauna", 380, 11, "Toronto Plaza Suites", 200.0, 5 },
                    { 5, "Free WiFi, Gym, Hot Tub, Sauna, Pool", 430, 22, "Sunshine Vista Hotel", 320.0, 4 },
                    { 6, "Free WiFi, Gym, Pool, Sauna", 350, 7, "City Center Hotel", 200.0, 5 },
                    { 7, "Free WiFi, Gym, Hot Tub, Sauna, Pool", 950, 5, "Grand Plaza Hotel", 175.0, 4 },
                    { 8, "Free WiFi, Gym, Pool, Sauna", 350, 9, "Riverside Inn", 200.0, 5 },
                    { 9, "Free WiFi, Gym, Hot Tub, Sauna, Pool", 950, 14, "Parkside Hotel", 175.0, 4 },
                    { 10, "Free WiFi, Gym, Pool, Sauna", 350, 11, "Metro Hotel", 200.0, 5 },
                    { 11, "Pool, Free WiFi, Gym", 75, 28, "Gateway Suites", 150.0, 5 },
                    { 12, "Free WiFi, Gym", 350, 2, "Capital Hotel", 200.0, 4 },
                    { 13, "Free WiFi, Gym, Hot Tub, Sauna, Pool", 950, 13, "Highland Inn", 175.0, 4 },
                    { 14, "Free WiFi, Gym, Pool, Sauna", 350, 30, "Coastal Hotel", 200.0, 5 },
                    { 15, "Free WiFi, Gym, Hot Tub, Sauna, Pool", 950, 27, "Sunset Hotel", 175.0, 4 },
                    { 16, "Free WiFi, Gym, Pool, Sauna", 350, 16, "Crown Hotel", 200.0, 5 },
                    { 17, "Free WiFi, Gym, Hot Tub, Sauna, Pool", 950, 17, "Regal Inn", 175.0, 4 },
                    { 18, "Free WiFi, Gym, Pool, Sauna", 350, 3, "Central Hotel", 200.0, 5 },
                    { 19, "Free WiFi, Gym, Hot Tub, Sauna, Pool", 950, 6, "Valley View Hotel", 175.0, 4 },
                    { 20, "Free WiFi, Gym, Pool, Sauna", 350, 11, "Trinity Hotel", 200.0, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_bookingTypeId",
                table: "Bookings",
                column: "bookingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_cityId",
                table: "Bookings",
                column: "cityId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_hotelId",
                table: "Bookings",
                column: "hotelId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_userId",
                table: "Bookings",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_CarRentals_BookingId",
                table: "CarRentals",
                column: "BookingId",
                unique: true,
                filter: "[BookingId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_BookingId",
                table: "Flights",
                column: "BookingId",
                unique: true,
                filter: "[BookingId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_CityId",
                table: "Hotels",
                column: "CityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarRentals");

            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "BookingTypes");

            migrationBuilder.DropTable(
                name: "Hotels");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
