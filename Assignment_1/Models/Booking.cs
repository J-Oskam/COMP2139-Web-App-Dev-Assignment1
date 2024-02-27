using System.ComponentModel.DataAnnotations;
namespace Assignment_1.Models
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }

        [DataType(DataType.Date)]
        public DateTime BookingDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        public int? passengers { get; set; }

        public int? numberOfDays { get; set; }

        public double TotalPrice { get; set; } //needs to be 8 digits with 2 decimal places

        public int ConfirmationNumber { get; set; } //unique

        //foreign keys from the other tables and their navigation properties
        [MaxLength(10)]
        public int? userId { get; set; }//foreign key
        public User? User { get; set; }//navigation property

        public int? hotelId { get; set; }
        public Hotel? Hotel { get; set; }

        public int? flightId { get; set; }
        public Flight? Flight { get; set; }

        public int? cityId { get; set; }
        public City? City { get; set; }

        public int? rentalId { get; set; }
        public CarRental? CarRental { get; set; }

        public int bookingTypeId { get; set; }
        public BookingType? BookingType { get; set; }

        //validates end date against start date
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (EndDate < StartDate)
            {
                yield return new ValidationResult("The start date must be after the end date.",
                    new[] { nameof(EndDate), nameof(StartDate) });
            }
        }
    }
}