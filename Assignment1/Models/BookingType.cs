using System.ComponentModel.DataAnnotations;

namespace Assignment1.Models {
    public class BookingType {
        [Key]
        public int BookingTypeId { get; set; }

        [MaxLength(100)]
        public string TypeName { get; set; }
    }
}
