using Microsoft.EntityFrameworkCore;

namespace Assignment1.Models
{
    public class FlightContext : DbContext
    {
        public FlightContext( DbContextOptions<FlightContext> options)
            : base(options)
            {}
        public DbSet <Flight> Flights { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Flight>().HasData(

            new Flight
            {
                FlightId = 1,
                Airline = "Air Canada",
                Airport = "Toronto Pearson",
                ArrivalTime = new DateTime(2021, 8, 4, 23, 58, 30, 999),
                DepartureTime = new DateTime(2021, 8, 4, 23, 58, 30, 999),
                Availability = "99",
                Price = 304,
                Specifications = "Economy class",
                Location = "Japan"
            },

            new Flight
            {
                FlightId = 2,
                Airline = "United Airlines",
                Airport = "Toronto Pearson",
                ArrivalTime = new DateTime(2022, 8, 4, 23, 58, 30, 999),
                DepartureTime = new DateTime(2022, 8, 4, 23, 58, 30, 999),
                Availability = "5",
                Price = 200,
                Specifications = "Economy class",
                Location = "USA"
            }
         );
        }
    }
}
