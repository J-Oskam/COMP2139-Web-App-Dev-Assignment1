using Assignment1.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;

namespace Assignment1.Models
{
    public class City
    {
        [Key]
        public int CityId { get; set; }

        [Required(ErrorMessage = "Please enter a valid city name")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "City name must be between 2 and 50 characters long")]
        public string CityName { get; set; }

        [Required(ErrorMessage = "Please select a valid country")]
        public int CountryId { get; set; }

        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }

        public virtual ICollection<Hotel> Hotels { get; set; } = new List<Hotel>();
    }
}
