using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GpBooking.Models
{
    [Table("RestaurantImages")]
    public class RestaurantImages
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Required]
        public string Image { get; set; }
        [ForeignKey("Restaurant")]
        public int RestaurantId { get; set; }

        public virtual Restaurant Restaurant { get; set; }
    }
}
