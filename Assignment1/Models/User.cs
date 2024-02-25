using System.ComponentModel.DataAnnotations;

namespace Assignment1.Models
{
    public class User
    {
        [Key]
        [Required]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Please enter your E-mail address")]
        [EmailAddress, StringLength(100, MinimumLength = 5, ErrorMessage = "Please enter a valid E-mail address")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Please enter your first name")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Please enter a valid first name")]
        public required string FirstName { get; set; }

        [StringLength(50, MinimumLength = 1, ErrorMessage = "Please enter a valid middle name")]
        public string? MiddleName { get; set; } = null;

        [Required(ErrorMessage = "Please enter your last name")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Please enter a valid last name")]
        public required string LastName { get; set; }

        public string? PasswordHash { get; set; }

        [Required]
        public Boolean IsGuest { get; set; }
    }
}
