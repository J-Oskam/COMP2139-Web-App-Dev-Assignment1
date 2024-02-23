using System.ComponentModel.DataAnnotations;

namespace Assignment1.Models {
    public class BookingType {
        [Key]
        public int BookingTypeId;

        [MaxLength(100)]
        public string TypeName;
    }
}
