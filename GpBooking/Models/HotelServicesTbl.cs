using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GpBooking.Models
{
    [Table("HotelServicesTbl")]
    public class HotelServicesTbl
    {
        public int id { get; set; }

        public int hotel_id { get; set; }

        [Required]
        [StringLength(100)]
        public string service { get; set; }

        public virtual HotelsTbl HotelsTbl { get; set; }
    }
}
