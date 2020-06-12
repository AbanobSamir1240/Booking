using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GpBooking.Models
{
    [Table("Restaurant")]
    public class Restaurant
    {
        public Restaurant()
        {
            RestaurantDishs = new HashSet<RestaurantDishs>();
            RestaurantImages = new HashSet<RestaurantImages>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Required]
        public string ShortName { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [StringLength(15)]
        public string Tel1 { get; set; }

        [StringLength(15)]
        public string Tel2 { get; set; }

        [Required]
        public string About { get; set; }

        public virtual ICollection<RestaurantDishs> RestaurantDishs { get; set; }

        public virtual ICollection<RestaurantImages> RestaurantImages { get; set; }
    }
}
