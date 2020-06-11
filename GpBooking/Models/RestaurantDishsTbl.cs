namespace Booking.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RestaurantDishsTbl")]
    public partial class RestaurantDishsTbl
    {
        public int id { get; set; }

        public int restaurant_id { get; set; }

        [Required]
        [StringLength(50)]
        public string dish_name { get; set; }

        public double price { get; set; }

        [StringLength(150)]
        public string image { get; set; }

        public virtual RestaurantsTbl RestaurantsTbl { get; set; }
    }
}
