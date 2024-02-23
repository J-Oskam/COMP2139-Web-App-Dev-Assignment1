using System.ComponentModel.DataAnnotations;
namespace Assignment1.Models {
    public class Bookings {
        [Key]
        public string BookingId { get; set; }

        [DataType(DataType.Date)]
        public DateTime BookingDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        public float TotalPrice { get; set; } //needs to be 8 digits with 2 decimal places

        public string ConfirmationNumber { get; set; } //unique

        //foreign keys from the other tables and their navigation properties
        [MaxLength(10)]
        public string userId { get; set; }

        public int bookingTypeId { get; set; } //foreign key

        public BookingType BookingType { get; set; } //navigation property

        [MaxLength(10)]
        public string? flightId { get; set; } //add navigation properties once known

        [MaxLength(10)]
        public string? rentalId { get; set; }

        [MaxLength(10)]
        public string? hotelId { get; set; }

        //validates end date against start date
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext) {
            if (EndDate < StartDate) {
                yield return new ValidationResult("The start date must be after the end date.",
                    new[] {nameof(EndDate),nameof(StartDate)});
            }
        }
    }
}
