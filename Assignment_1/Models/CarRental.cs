using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment_1.Models
{
    public class CarRental
    {
        [Key]
        public int RentalId { get; set; }

        public required string Location { get; set; }

        public required string RentalCompany { get; set; }
        public required int Availability { get; set; }

        public int Price { get; set; }

        //public List<TransportationDetails>? CarDetails {  get; set; }
        public int CarYear { get; set; }

        public required string CarMake { get; set; }

        public required string CarModel { get; set; }

        public required string Specifications { get; set; }

        [ForeignKey("Booking")]
        public int? BookingId { get; set; }
        public virtual Booking? Booking { get; set; }

        public void rentCar()
        {
            Availability -= 1;
        }
    }
}
