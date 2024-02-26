﻿// <auto-generated />
using System;
using Assignment_1.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Assignment_1.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240226021035_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Assignment_1.Models.Booking", b =>
                {
                    b.Property<int>("BookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookingId"));

                    b.Property<DateTime>("BookingDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ConfirmationNumber")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("float");

                    b.Property<int>("bookingTypeId")
                        .HasColumnType("int");

                    b.Property<int?>("cityId")
                        .HasColumnType("int");

                    b.Property<int?>("flightId")
                        .HasColumnType("int");

                    b.Property<int?>("hotelId")
                        .HasColumnType("int");

                    b.Property<int?>("rentalId")
                        .HasColumnType("int");

                    b.Property<int?>("userId")
                        .HasMaxLength(10)
                        .HasColumnType("int");

                    b.HasKey("BookingId");

                    b.HasIndex("bookingTypeId");

                    b.HasIndex("cityId");

                    b.HasIndex("hotelId");

                    b.HasIndex("userId");

                    b.ToTable("Bookings");

                    b.HasData(
                        new
                        {
                            BookingId = 18,
                            BookingDate = new DateTime(2024, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ConfirmationNumber = 45875,
                            EndDate = new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StartDate = new DateTime(2024, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TotalPrice = 850.0,
                            bookingTypeId = 1
                        },
                        new
                        {
                            BookingId = 51,
                            BookingDate = new DateTime(2024, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ConfirmationNumber = 45876,
                            EndDate = new DateTime(2025, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StartDate = new DateTime(2025, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TotalPrice = 760.5,
                            bookingTypeId = 1
                        });
                });

            modelBuilder.Entity("Assignment_1.Models.BookingType", b =>
                {
                    b.Property<int>("BookingTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookingTypeId"));

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("BookingTypeId");

                    b.ToTable("BookingTypes");

                    b.HasData(
                        new
                        {
                            BookingTypeId = 1,
                            TypeName = "Hotel"
                        });
                });

            modelBuilder.Entity("Assignment_1.Models.CarRental", b =>
                {
                    b.Property<int>("RentalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RentalId"));

                    b.Property<int>("Availability")
                        .HasColumnType("int");

                    b.Property<int?>("BookingId")
                        .HasColumnType("int");

                    b.Property<string>("CarMake")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CarModel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CarYear")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("RentalCompany")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Specifications")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RentalId");

                    b.HasIndex("BookingId")
                        .IsUnique()
                        .HasFilter("[BookingId] IS NOT NULL");

                    b.ToTable("CarRentals");

                    b.HasData(
                        new
                        {
                            RentalId = 1,
                            Availability = 5,
                            CarMake = "Toyota",
                            CarModel = "Camry",
                            CarYear = 2007,
                            Location = "Canada",
                            Price = 304,
                            RentalCompany = "Cards5U",
                            Specifications = "Gray car"
                        },
                        new
                        {
                            RentalId = 2,
                            Availability = 2,
                            CarMake = "Toyota",
                            CarModel = "Camry",
                            CarYear = 2007,
                            Location = "Canada",
                            Price = 30,
                            RentalCompany = "Cards5U",
                            Specifications = "Red car"
                        });
                });

            modelBuilder.Entity("Assignment_1.Models.City", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CityId"));

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.HasKey("CityId");

                    b.HasIndex("CountryId");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            CityId = 1,
                            CityName = "New York",
                            CountryId = 1
                        },
                        new
                        {
                            CityId = 2,
                            CityName = "Los Angeles",
                            CountryId = 1
                        },
                        new
                        {
                            CityId = 3,
                            CityName = "Chicago",
                            CountryId = 1
                        },
                        new
                        {
                            CityId = 4,
                            CityName = "Houston",
                            CountryId = 1
                        },
                        new
                        {
                            CityId = 5,
                            CityName = "Phoenix",
                            CountryId = 1
                        },
                        new
                        {
                            CityId = 6,
                            CityName = "Philadelphia",
                            CountryId = 1
                        },
                        new
                        {
                            CityId = 7,
                            CityName = "San Antonio",
                            CountryId = 1
                        },
                        new
                        {
                            CityId = 8,
                            CityName = "San Diego",
                            CountryId = 1
                        },
                        new
                        {
                            CityId = 9,
                            CityName = "Dallas",
                            CountryId = 1
                        },
                        new
                        {
                            CityId = 10,
                            CityName = "San Jose",
                            CountryId = 1
                        },
                        new
                        {
                            CityId = 11,
                            CityName = "Toronto",
                            CountryId = 2
                        },
                        new
                        {
                            CityId = 12,
                            CityName = "Montreal",
                            CountryId = 2
                        },
                        new
                        {
                            CityId = 13,
                            CityName = "Vancouver",
                            CountryId = 2
                        },
                        new
                        {
                            CityId = 14,
                            CityName = "Calgary",
                            CountryId = 2
                        },
                        new
                        {
                            CityId = 15,
                            CityName = "Edmonton",
                            CountryId = 2
                        },
                        new
                        {
                            CityId = 16,
                            CityName = "Ottawa",
                            CountryId = 2
                        },
                        new
                        {
                            CityId = 17,
                            CityName = "Winnipeg",
                            CountryId = 2
                        },
                        new
                        {
                            CityId = 18,
                            CityName = "Quebec City",
                            CountryId = 2
                        },
                        new
                        {
                            CityId = 19,
                            CityName = "Hamilton",
                            CountryId = 2
                        },
                        new
                        {
                            CityId = 20,
                            CityName = "Kitchener",
                            CountryId = 2
                        },
                        new
                        {
                            CityId = 21,
                            CityName = "Mexico City",
                            CountryId = 3
                        },
                        new
                        {
                            CityId = 22,
                            CityName = "Guadalajara",
                            CountryId = 3
                        },
                        new
                        {
                            CityId = 23,
                            CityName = "Monterrey",
                            CountryId = 3
                        },
                        new
                        {
                            CityId = 24,
                            CityName = "Puebla",
                            CountryId = 3
                        },
                        new
                        {
                            CityId = 25,
                            CityName = "Toluca",
                            CountryId = 3
                        },
                        new
                        {
                            CityId = 26,
                            CityName = "Tijuana",
                            CountryId = 3
                        },
                        new
                        {
                            CityId = 27,
                            CityName = "León",
                            CountryId = 3
                        },
                        new
                        {
                            CityId = 28,
                            CityName = "Ciudad Juárez",
                            CountryId = 3
                        },
                        new
                        {
                            CityId = 29,
                            CityName = "Torreón",
                            CountryId = 3
                        },
                        new
                        {
                            CityId = 30,
                            CityName = "San Luis Potosí",
                            CountryId = 3
                        });
                });

            modelBuilder.Entity("Assignment_1.Models.Country", b =>
                {
                    b.Property<int>("CountryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CountryId"));

                    b.Property<string>("CountryName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CountryId");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            CountryId = 1,
                            CountryName = "United States"
                        },
                        new
                        {
                            CountryId = 2,
                            CountryName = "Canada"
                        },
                        new
                        {
                            CountryId = 3,
                            CountryName = "Mexico"
                        });
                });

            modelBuilder.Entity("Assignment_1.Models.Flight", b =>
                {
                    b.Property<int>("FlightId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FlightId"));

                    b.Property<string>("Airline")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Airport")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ArrivalTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Availability")
                        .HasColumnType("int");

                    b.Property<int?>("BookingId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DepartureTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("Specifications")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FlightId");

                    b.HasIndex("BookingId")
                        .IsUnique()
                        .HasFilter("[BookingId] IS NOT NULL");

                    b.ToTable("Flights");

                    b.HasData(
                        new
                        {
                            FlightId = 1,
                            Airline = "Air Canada",
                            Airport = "Toronto Pearson",
                            ArrivalTime = new DateTime(2021, 8, 4, 23, 58, 30, 999, DateTimeKind.Unspecified),
                            Availability = 99,
                            DepartureTime = new DateTime(2021, 8, 4, 23, 58, 30, 999, DateTimeKind.Unspecified),
                            Location = "Japan",
                            Price = 304,
                            Specifications = "Economy class"
                        },
                        new
                        {
                            FlightId = 2,
                            Airline = "United Airlines",
                            Airport = "Toronto Pearson",
                            ArrivalTime = new DateTime(2022, 8, 4, 23, 58, 30, 999, DateTimeKind.Unspecified),
                            Availability = 5,
                            DepartureTime = new DateTime(2022, 8, 4, 23, 58, 30, 999, DateTimeKind.Unspecified),
                            Location = "USA",
                            Price = 200,
                            Specifications = "Economy class"
                        });
                });

            modelBuilder.Entity("Assignment_1.Models.Hotel", b =>
                {
                    b.Property<int>("HotelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HotelId"));

                    b.Property<string>("Amenities")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AvailableRooms")
                        .HasColumnType("int");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("HotelName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<double>("Pricing")
                        .HasColumnType("float");

                    b.Property<int?>("Rating")
                        .HasColumnType("int");

                    b.HasKey("HotelId");

                    b.HasIndex("CityId");

                    b.ToTable("Hotels");

                    b.HasData(
                        new
                        {
                            HotelId = 1,
                            Amenities = "Pool, Free WiFi, Gym",
                            AvailableRooms = 75,
                            CityId = 2,
                            HotelName = "Hotel California",
                            Pricing = 150.0,
                            Rating = 5
                        },
                        new
                        {
                            HotelId = 2,
                            Amenities = "Free WiFi, Gym",
                            AvailableRooms = 350,
                            CityId = 1,
                            HotelName = "The Big Apple Hotel",
                            Pricing = 200.0,
                            Rating = 4
                        },
                        new
                        {
                            HotelId = 3,
                            Amenities = "Free WiFi, Gym, Hot Tub, Sauna, Pool",
                            AvailableRooms = 950,
                            CityId = 8,
                            HotelName = "The Estate Hotel",
                            Pricing = 175.0,
                            Rating = 4
                        },
                        new
                        {
                            HotelId = 4,
                            Amenities = "Free WiFi, Gym, Pool, Sauna",
                            AvailableRooms = 380,
                            CityId = 11,
                            HotelName = "Toronto Plaza Suites",
                            Pricing = 200.0,
                            Rating = 5
                        },
                        new
                        {
                            HotelId = 5,
                            Amenities = "Free WiFi, Gym, Hot Tub, Sauna, Pool",
                            AvailableRooms = 430,
                            CityId = 22,
                            HotelName = "Sunshine Vista Hotel",
                            Pricing = 320.0,
                            Rating = 4
                        },
                        new
                        {
                            HotelId = 6,
                            Amenities = "Free WiFi, Gym, Pool, Sauna",
                            AvailableRooms = 350,
                            CityId = 7,
                            HotelName = "City Center Hotel",
                            Pricing = 200.0,
                            Rating = 5
                        },
                        new
                        {
                            HotelId = 7,
                            Amenities = "Free WiFi, Gym, Hot Tub, Sauna, Pool",
                            AvailableRooms = 950,
                            CityId = 5,
                            HotelName = "Grand Plaza Hotel",
                            Pricing = 175.0,
                            Rating = 4
                        },
                        new
                        {
                            HotelId = 8,
                            Amenities = "Free WiFi, Gym, Pool, Sauna",
                            AvailableRooms = 350,
                            CityId = 9,
                            HotelName = "Riverside Inn",
                            Pricing = 200.0,
                            Rating = 5
                        },
                        new
                        {
                            HotelId = 9,
                            Amenities = "Free WiFi, Gym, Hot Tub, Sauna, Pool",
                            AvailableRooms = 950,
                            CityId = 14,
                            HotelName = "Parkside Hotel",
                            Pricing = 175.0,
                            Rating = 4
                        },
                        new
                        {
                            HotelId = 10,
                            Amenities = "Free WiFi, Gym, Pool, Sauna",
                            AvailableRooms = 350,
                            CityId = 11,
                            HotelName = "Metro Hotel",
                            Pricing = 200.0,
                            Rating = 5
                        },
                        new
                        {
                            HotelId = 11,
                            Amenities = "Pool, Free WiFi, Gym",
                            AvailableRooms = 75,
                            CityId = 28,
                            HotelName = "Gateway Suites",
                            Pricing = 150.0,
                            Rating = 5
                        },
                        new
                        {
                            HotelId = 12,
                            Amenities = "Free WiFi, Gym",
                            AvailableRooms = 350,
                            CityId = 2,
                            HotelName = "Capital Hotel",
                            Pricing = 200.0,
                            Rating = 4
                        },
                        new
                        {
                            HotelId = 13,
                            Amenities = "Free WiFi, Gym, Hot Tub, Sauna, Pool",
                            AvailableRooms = 950,
                            CityId = 13,
                            HotelName = "Highland Inn",
                            Pricing = 175.0,
                            Rating = 4
                        },
                        new
                        {
                            HotelId = 14,
                            Amenities = "Free WiFi, Gym, Pool, Sauna",
                            AvailableRooms = 350,
                            CityId = 30,
                            HotelName = "Coastal Hotel",
                            Pricing = 200.0,
                            Rating = 5
                        },
                        new
                        {
                            HotelId = 15,
                            Amenities = "Free WiFi, Gym, Hot Tub, Sauna, Pool",
                            AvailableRooms = 950,
                            CityId = 27,
                            HotelName = "Sunset Hotel",
                            Pricing = 175.0,
                            Rating = 4
                        },
                        new
                        {
                            HotelId = 16,
                            Amenities = "Free WiFi, Gym, Pool, Sauna",
                            AvailableRooms = 350,
                            CityId = 16,
                            HotelName = "Crown Hotel",
                            Pricing = 200.0,
                            Rating = 5
                        },
                        new
                        {
                            HotelId = 17,
                            Amenities = "Free WiFi, Gym, Hot Tub, Sauna, Pool",
                            AvailableRooms = 950,
                            CityId = 17,
                            HotelName = "Regal Inn",
                            Pricing = 175.0,
                            Rating = 4
                        },
                        new
                        {
                            HotelId = 18,
                            Amenities = "Free WiFi, Gym, Pool, Sauna",
                            AvailableRooms = 350,
                            CityId = 3,
                            HotelName = "Central Hotel",
                            Pricing = 200.0,
                            Rating = 5
                        },
                        new
                        {
                            HotelId = 19,
                            Amenities = "Free WiFi, Gym, Hot Tub, Sauna, Pool",
                            AvailableRooms = 950,
                            CityId = 6,
                            HotelName = "Valley View Hotel",
                            Pricing = 175.0,
                            Rating = 4
                        },
                        new
                        {
                            HotelId = 20,
                            Amenities = "Free WiFi, Gym, Pool, Sauna",
                            AvailableRooms = 350,
                            CityId = 11,
                            HotelName = "Trinity Hotel",
                            Pricing = 200.0,
                            Rating = 5
                        });
                });

            modelBuilder.Entity("Assignment_1.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsGuest")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("MiddleName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Assignment_1.Models.Booking", b =>
                {
                    b.HasOne("Assignment_1.Models.BookingType", "BookingType")
                        .WithMany()
                        .HasForeignKey("bookingTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Assignment_1.Models.City", "City")
                        .WithMany()
                        .HasForeignKey("cityId");

                    b.HasOne("Assignment_1.Models.Hotel", "Hotel")
                        .WithMany()
                        .HasForeignKey("hotelId");

                    b.HasOne("Assignment_1.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("userId");

                    b.Navigation("BookingType");

                    b.Navigation("City");

                    b.Navigation("Hotel");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Assignment_1.Models.CarRental", b =>
                {
                    b.HasOne("Assignment_1.Models.Booking", "Booking")
                        .WithOne("CarRental")
                        .HasForeignKey("Assignment_1.Models.CarRental", "BookingId");

                    b.Navigation("Booking");
                });

            modelBuilder.Entity("Assignment_1.Models.City", b =>
                {
                    b.HasOne("Assignment_1.Models.Country", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Assignment_1.Models.Flight", b =>
                {
                    b.HasOne("Assignment_1.Models.Booking", "Booking")
                        .WithOne("Flight")
                        .HasForeignKey("Assignment_1.Models.Flight", "BookingId");

                    b.Navigation("Booking");
                });

            modelBuilder.Entity("Assignment_1.Models.Hotel", b =>
                {
                    b.HasOne("Assignment_1.Models.City", "City")
                        .WithMany("Hotels")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("Assignment_1.Models.Booking", b =>
                {
                    b.Navigation("CarRental");

                    b.Navigation("Flight");
                });

            modelBuilder.Entity("Assignment_1.Models.City", b =>
                {
                    b.Navigation("Hotels");
                });

            modelBuilder.Entity("Assignment_1.Models.Country", b =>
                {
                    b.Navigation("Cities");
                });
#pragma warning restore 612, 618
        }
    }
}
