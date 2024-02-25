namespace Assignment1.Models
{
    public class CarRental
    {

        public int RentalId { get; set; }

        public required string Location { get; set; }

        public required string RentalCompany { get; set; }
        public required string Availability { get; set; }

        public int Price { get; set; }

        //public List<TransportationDetails>? CarDetails {  get; set; }
        public int CarYear { get; set; }

        public required string CarMake { get; set; }

        public required string CarModel { get; set; }

        public required string Specifications { get; set; }
    }
}
