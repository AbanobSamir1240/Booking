namespace Booking.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HotelServicesTbl")]
    public partial class HotelServicesTbl
    {
        public int id { get; set; }

        public int hotel_id { get; set; }

        [Required]
        [StringLength(100)]
        public string service { get; set; }

        public virtual HotelsTbl HotelsTbl { get; set; }
    }
}
