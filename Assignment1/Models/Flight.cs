using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Components.Forms;

namespace Assignment1.Models
{
    public class Flight
    {
        public int FlightId { get; set; }

        public required string Airport { get; set; }

        public required string Airline{ get; set; }
        public required string Availability { get; set; }

        public int Price { get; set; }

        [DataType(DataType.Date)]
        public DateTime DepartureTime { get; set; }

        [DataType(DataType.Date)]
        public DateTime ArrivalTime { get; set; }

        //public List<TransportationDetails>? CarDetails {  get; set; }

        public required string Specifications { get; set; }
    }
}
