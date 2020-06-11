using System.ComponentModel.DataAnnotations.Schema;

namespace GpBooking.Models
{
    [Table("HotelRoomsTbl")]
    public class HotelRoomsTbl
    {
        public int id { get; set; }

        public int hotel_id { get; set; }

        public int room_type_id { get; set; }

        public double price { get; set; }

        public virtual HotelRoomTypesTbl HotelRoomTypesTbl { get; set; }

        public virtual HotelsTbl HotelsTbl { get; set; }
    }
}
