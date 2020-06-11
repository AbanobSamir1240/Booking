namespace Booking.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HotelRoomsTbl")]
    public partial class HotelRoomsTbl
    {
        public int id { get; set; }

        public int hotel_id { get; set; }

        public int room_type_id { get; set; }

        public double price { get; set; }

        public virtual HotelRoomTypesTbl HotelRoomTypesTbl { get; set; }

        public virtual HotelsTbl HotelsTbl { get; set; }
    }
}
