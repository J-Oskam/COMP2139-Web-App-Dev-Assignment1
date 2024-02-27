using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Assignment_1.Migrations
{
    /// <inheritdoc />
    public partial class migration_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CarRentals",
                columns: new[] { "RentalId", "Availability", "BookingId", "CarMake", "CarModel", "CarYear", "Location", "Price", "RentalCompany", "Specifications" },
                values: new object[,]
                {
                    { 30, 5, null, "Toyota", "Camry", 2007, "Italy", 90, "Cars4U", "gray car" },
                    { 31, 3, null, "Honda", "Civic", 2009, "France", 60, "Cars4U", "Red car" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CarRentals",
                keyColumn: "RentalId",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "CarRentals",
                keyColumn: "RentalId",
                keyValue: 31);
        }
    }
}
