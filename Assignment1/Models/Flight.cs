using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Components.Forms;

namespace Assignment1.Models
{
    public class Flight
    {
        public int FlightId { get; set; }

        public required string Airport { get; set; }

        public required string Airline{ get; set; }
        public required int Availability { get; set; }

        public int Price { get; set; }

        [DataType(DataType.Date)]
        public DateTime DepartureTime { get; set; }

        [DataType(DataType.Date)]
        public DateTime ArrivalTime { get; set; }

        public required string Location { get; set; }

        //public List<TransportationDetails>? CarDetails {  get; set; }

        public required string Specifications { get; set; }

        /*
        [ForeignKey("Booking")]
        public int BookingId { get; set; }
        public virtual Bookings? Booking { get; set; } 
        */

        public void BookSeat()
        {
            Availability -= 1;
        }


    }
}
