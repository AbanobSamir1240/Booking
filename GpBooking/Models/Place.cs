using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GpBooking.Models
{
    [Table("Place")]
    public class Place
    {
        public Place()
        {
            PlacesSubitems = new HashSet<PlacesSubitems>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string ShortName { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public string About { get; set; }
        public string Image { get; set; }

        public virtual ICollection<PlacesSubitems> PlacesSubitems { get; set; }
    }
}
