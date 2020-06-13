using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GpBooking.Models
{
    [Table("RestaurantDishs")]
    public class RestaurantDishs
    {

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        

        [Required]
        public string DishName { get; set; }

        public decimal Price { get; set; }

        public string Image { get; set; }
        [ForeignKey("Restaurant")]
        public int RestaurantId { get; set; }

        public virtual Restaurant Restaurant { get; set; }
    }
}
