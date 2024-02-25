using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment1.Models
{
    public class Hotel
    {
        [Key]
        [Required]
        public int HotelId { get; set; }

        [Required(ErrorMessage = "Please enter a valid hotel name")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "The input name must be between 2 and 100 characters long")]
        public string HotelName { get; set; } // Removed 'required' keyword

        [Required(ErrorMessage = "Please select a valid city")]
        public int CityId { get; set; }

        [ForeignKey("CityId")]
        public virtual City City { get; set; } // Removed 'required' keyword and made virtual for lazy loading

        [Required(ErrorMessage = "Please enter a price")]
        [Range(1, double.MaxValue, ErrorMessage = "Please enter a valid price")]
        public double Pricing { get; set; }

        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5")]
        public int? Rating { get; set; }

        [Required(ErrorMessage = "Please enter the number of available rooms")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a valid number of available rooms")]
        public int AvailableRooms { get; set; }

        public string? Amenities { get; set; }
    }
}