using System.ComponentModel.DataAnnotations;

namespace Assignment_1.Models
{
    public class Country
    {
        [Key]
        [Required]
        public int CountryId { get; set; }

        [Required(ErrorMessage = "Please enter a valid name")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Country name must be between 2 and 50 characters long")]
        public required string CountryName { get; set; }

        public virtual ICollection<City> Cities { get; set; } = new List<City>();
    }
}
