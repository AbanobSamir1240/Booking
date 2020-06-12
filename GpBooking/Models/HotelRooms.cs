using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GpBooking.Models
{
    [Table("HotelRooms")]
    public class HotelRooms
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public decimal Price { get; set; }
        [ForeignKey("HotelRoomType")]
        public int HotelRoomTypeId { get; set; }

        public virtual HotelRoomType HotelRoomType { get; set; }
        [ForeignKey("Hotel")]
        public int HotelId { get; set; }

        public virtual Hotel Hotel { get; set; }
    }
}
