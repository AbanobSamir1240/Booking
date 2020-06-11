using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GpBooking.Models
{
    [Table("RestaurantDishsTbl")]
    public class RestaurantDishsTbl
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
