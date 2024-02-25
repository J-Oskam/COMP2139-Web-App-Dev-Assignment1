using Microsoft.EntityFrameworkCore;
using Assignment_1.Models;

namespace Assignment_1.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<CarRental> CarRentals { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<BookingType> BookingTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasData(
                new Country { CountryId = 1, CountryName = "United States" },
                new Country { CountryId = 2, CountryName = "Canada" },
                new Country { CountryId = 3, CountryName = "Mexico" }
            );

            modelBuilder.Entity<City>().HasData(
                // American Cities
                new City { CityId = 1, CityName = "New York", CountryId = 1 },
                new City { CityId = 2, CityName = "Los Angeles", CountryId = 1 },
                new City { CityId = 3, CityName = "Chicago", CountryId = 1 },
                new City { CityId = 4, CityName = "Houston", CountryId = 1 },
                new City { CityId = 5, CityName = "Phoenix", CountryId = 1 },
                new City { CityId = 6, CityName = "Philadelphia", CountryId = 1 },
                new City { CityId = 7, CityName = "San Antonio", CountryId = 1 },
                new City { CityId = 8, CityName = "San Diego", CountryId = 1 },
                new City { CityId = 9, CityName = "Dallas", CountryId = 1 },
                new City { CityId = 10, CityName = "San Jose", CountryId = 1 },
                // Canadian Cities
                new City { CityId = 11, CityName = "Toronto", CountryId = 2 },
                new City { CityId = 12, CityName = "Montreal", CountryId = 2 },
                new City { CityId = 13, CityName = "Vancouver", CountryId = 2 },
                new City { CityId = 14, CityName = "Calgary", CountryId = 2 },
                new City { CityId = 15, CityName = "Edmonton", CountryId = 2 },
                new City { CityId = 16, CityName = "Ottawa", CountryId = 2 },
                new City { CityId = 17, CityName = "Winnipeg", CountryId = 2 },
                new City { CityId = 18, CityName = "Quebec City", CountryId = 2 },
                new City { CityId = 19, CityName = "Hamilton", CountryId = 2 },
                new City { CityId = 20, CityName = "Kitchener", CountryId = 2 },
                // Mexican Cities
                new City { CityId = 21, CityName = "Mexico City", CountryId = 3 },
                new City { CityId = 22, CityName = "Guadalajara", CountryId = 3 },
                new City { CityId = 23, CityName = "Monterrey", CountryId = 3 },
                new City { CityId = 24, CityName = "Puebla", CountryId = 3 },
                new City { CityId = 25, CityName = "Toluca", CountryId = 3 },
                new City { CityId = 26, CityName = "Tijuana", CountryId = 3 },
                new City { CityId = 27, CityName = "León", CountryId = 3 },
                new City { CityId = 28, CityName = "Ciudad Juárez", CountryId = 3 },
                new City { CityId = 29, CityName = "Torreón", CountryId = 3 },
                new City { CityId = 30, CityName = "San Luis Potosí", CountryId = 3 }
            );

            modelBuilder.Entity<Hotel>().HasData(
                new Hotel
                {
                    HotelId = 1,
                    HotelName = "Hotel California",
                    CityId = 2,
                    Pricing = 150.00,
                    Rating = 5,
                    AvailableRooms = 75,
                    Amenities = "Pool, Free WiFi, Gym"
                },
                new Hotel
                {
                    HotelId = 2,
                    HotelName = "The Big Apple Hotel",
                    CityId = 1,
                    Pricing = 200.00,
                    Rating = 4,
                    AvailableRooms = 350,
                    Amenities = "Free WiFi, Gym"
                },
                new Hotel
                {
                    HotelId = 3,
                    HotelName = "The Estate Hotel",
                    CityId = 8,
                    Pricing = 175.00,
                    Rating = 4,
                    AvailableRooms = 950,
                    Amenities = "Free WiFi, Gym, Hot Tub, Sauna, Pool"
                },
                new Hotel
                {
                    HotelId = 4,
                    HotelName = "Toronto Plaza Suites",
                    CityId = 11,
                    Pricing = 200.00,
                    Rating = 5,
                    AvailableRooms = 380,
                    Amenities = "Free WiFi, Gym, Pool, Sauna"
                },
                new Hotel
                {
                    HotelId = 5,
                    HotelName = "Sunshine Vista Hotel",
                    CityId = 22,
                    Pricing = 320.00,
                    Rating = 4,
                    AvailableRooms = 430,
                    Amenities = "Free WiFi, Gym, Hot Tub, Sauna, Pool"
                },
                new Hotel
                {
                    HotelId = 6,
                    HotelName = "City Center Hotel",
                    CityId = 7,
                    Pricing = 200.00,
                    Rating = 5,
                    AvailableRooms = 350,
                    Amenities = "Free WiFi, Gym, Pool, Sauna"
                },
                new Hotel
                {
                    HotelId = 7,
                    HotelName = "Grand Plaza Hotel",
                    CityId = 5,
                    Pricing = 175.00,
                    Rating = 4,
                    AvailableRooms = 950,
                    Amenities = "Free WiFi, Gym, Hot Tub, Sauna, Pool"
                },
                new Hotel
                {
                    HotelId = 8,
                    HotelName = "Riverside Inn",
                    CityId = 9,
                    Pricing = 200.00,
                    Rating = 5,
                    AvailableRooms = 350,
                    Amenities = "Free WiFi, Gym, Pool, Sauna"
                },
                new Hotel
                {
                    HotelId = 9,
                    HotelName = "Parkside Hotel",
                    CityId = 14,
                    Pricing = 175.00,
                    Rating = 4,
                    AvailableRooms = 950,
                    Amenities = "Free WiFi, Gym, Hot Tub, Sauna, Pool"
                },
                new Hotel
                {
                    HotelId = 10,
                    HotelName = "Metro Hotel",
                    CityId = 11,
                    Pricing = 200.00,
                    Rating = 5,
                    AvailableRooms = 350,
                    Amenities = "Free WiFi, Gym, Pool, Sauna"
                },
                new Hotel
                {
                    HotelId = 11,
                    HotelName = "Gateway Suites",
                    CityId = 28,
                    Pricing = 150.00,
                    Rating = 5,
                    AvailableRooms = 75,
                    Amenities = "Pool, Free WiFi, Gym"
                },
                new Hotel
                {
                    HotelId = 12,
                    HotelName = "Capital Hotel",
                    CityId = 2,
                    Pricing = 200.00,
                    Rating = 4,
                    AvailableRooms = 350,
                    Amenities = "Free WiFi, Gym"
                },
                new Hotel
                {
                    HotelId = 13,
                    HotelName = "Highland Inn",
                    CityId = 13,
                    Pricing = 175.00,
                    Rating = 4,
                    AvailableRooms = 950,
                    Amenities = "Free WiFi, Gym, Hot Tub, Sauna, Pool"
                },
                new Hotel
                {
                    HotelId = 14,
                    HotelName = "Coastal Hotel",
                    CityId = 30,
                    Pricing = 200.00,
                    Rating = 5,
                    AvailableRooms = 350,
                    Amenities = "Free WiFi, Gym, Pool, Sauna"
                },
                new Hotel
                {
                    HotelId = 15,
                    HotelName = "Sunset Hotel",
                    CityId = 27,
                    Pricing = 175.00,
                    Rating = 4,
                    AvailableRooms = 950,
                    Amenities = "Free WiFi, Gym, Hot Tub, Sauna, Pool"
                },
                new Hotel
                {
                    HotelId = 16,
                    HotelName = "Crown Hotel",
                    CityId = 16,
                    Pricing = 200.00,
                    Rating = 5,
                    AvailableRooms = 350,
                    Amenities = "Free WiFi, Gym, Pool, Sauna"
                },
                new Hotel
                {
                    HotelId = 17,
                    HotelName = "Regal Inn",
                    CityId = 17,
                    Pricing = 175.00,
                    Rating = 4,
                    AvailableRooms = 950,
                    Amenities = "Free WiFi, Gym, Hot Tub, Sauna, Pool"
                },
                new Hotel
                {
                    HotelId = 18,
                    HotelName = "Central Hotel",
                    CityId = 3,
                    Pricing = 200.00,
                    Rating = 5,
                    AvailableRooms = 350,
                    Amenities = "Free WiFi, Gym, Pool, Sauna"
                },
                new Hotel
                {
                    HotelId = 19,
                    HotelName = "Valley View Hotel",
                    CityId = 6,
                    Pricing = 175.00,
                    Rating = 4,
                    AvailableRooms = 950,
                    Amenities = "Free WiFi, Gym, Hot Tub, Sauna, Pool"
                },
                new Hotel
                {
                    HotelId = 20,
                    HotelName = "Trinity Hotel",
                    CityId = 11,
                    Pricing = 200.00,
                    Rating = 5,
                    AvailableRooms = 350,
                    Amenities = "Free WiFi, Gym, Pool, Sauna"
                }
            );
        }
    }
}
