using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GpBooking.Models
{
    [Table("HotelReservationsTbl")]
    public partial class HotelReservationsTbl
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        public int user_id { get; set; }

        public int room_id { get; set; }

        [Column(TypeName = "date")]
        public DateTime reservation_date { get; set; }

        [Column(TypeName = "date")]
        public DateTime start_date { get; set; }

        [Column(TypeName = "date")]
        public DateTime? end_date { get; set; }
    }
}
