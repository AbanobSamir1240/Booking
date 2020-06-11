namespace Booking.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RestaurantImagesTbl")]
    public partial class RestaurantImagesTbl
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        public int restaurant_id { get; set; }

        [Required]
        [StringLength(150)]
        public string image { get; set; }

        public virtual RestaurantsTbl RestaurantsTbl { get; set; }
    }
}
