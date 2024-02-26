using System.ComponentModel.DataAnnotations;

namespace Assignment_1.Models
{
    public class BookingType
    {
        [Key]
        public int BookingTypeId { get; set; }

        [MaxLength(100)]
        public required string TypeName { get; set; }
    }
}
